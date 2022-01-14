using ERP.Data;
using ERP.Data.Identity;
using ERP.Models.Items;
using ERP.UnitOfWork;
using ERP.Utilities;
using ERP.Utilities.Helpers;
using ERP.Utilities.Services;
using ERP.Utilities.Services.EmailService;
using ERP.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ERP.Controllers.items
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors(PolicyName = "AllowOrigin")]
    public class ItemsController : ControllerBase
    {
        public ITokenService TokenService { get; }
        public DbContextOptions<ApplicationDbContext> DbOptions { get; }
        public ApplicationUserSignIngManager SignIngManager { get; }
        public IMailService MailService { get; }
        public ApplicationUserRoleManager RoleManager { get; }
        public ApplicationUserManager UserManager { get; set; }
        public Constants Constants { get; set; }
        public IUnitOfWork_ApplicationUser UserUnitOfWork { get; set; }
        public IUnitOfWork_Tenants TenantsUnitOfWork { get; set; }

        public ItemsController(ApplicationUserManager userManager, ITokenService tokenService, Constants constants,
            IUnitOfWork_ApplicationUser userUnitOfWork, DbContextOptions<ApplicationDbContext> dbOptions,
           IUnitOfWork_Tenants tenantsUnitOfWork, ApplicationUserSignIngManager signinManager, IMailService mailService,
           ApplicationUserRoleManager roleManager)
        {
            UserManager = userManager;
            TokenService = tokenService;
            Constants = constants;
            UserUnitOfWork = userUnitOfWork;
            DbOptions = dbOptions;
            SignIngManager = signinManager;
            MailService = mailService;
            RoleManager = roleManager;
            TenantsUnitOfWork = tenantsUnitOfWork;
        }

        #region Item Main Category Functions
        //Get all cats
        [HttpGet("allcategories")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<List<ItemMainCategory>>> GetItemCategories(string subomain)
        {
            if (CheckManuallyChanged_Subdomain(subomain))
            {
                var tenant = await TenantsUnitOfWork.Tenants.TenantBySubdomainAsync(subomain);
                if (tenant != null)
                {
                    await UserUnitOfWork.SetConnectionStringAsync(tenant.ConnectionString);

                    var allMainCats = await UserUnitOfWork.ItemMainCategory.GetAllAsync(includeProperties: "ItemSubCategory");
                    foreach(var main in allMainCats)
                    {
                        var letSubCats = await UserUnitOfWork.Item_SubCats.GetAllAsync(
                            x => x.ItemMainCategoryId == main.Id);
                        if(letSubCats.ToList().Count == 0)
                        {
                            await UserUnitOfWork.Item_SubCats.AddAsync(new ItemSubCategory
                            {
                                ItemMainCategoryId = main.Id,
                                SubCatName = "Default Subcategory"
                            });
                            await UserUnitOfWork.SaveAsync();
                        }
                    }
                    return allMainCats.ToList();
                }
                return BadRequest(Constants.NullTentant_Error_Response());
            }
            return BadRequest(Constants.HackTrying_Error_Response());
        }
        //Add new Main Cat
        [HttpPost(nameof(AddMainCategory))]
        [Authorize]
        [ValidateAntiForgeryTokenCustom]
        public async Task<IActionResult> AddMainCategory(ItemMainCategory NewCat)
        {
            if (CheckManuallyChanged_Subdomain(NewCat.Subdomain))
            {
                var tenant = await TenantsUnitOfWork.Tenants.TenantBySubdomainAsync(NewCat.Subdomain);
                if (tenant != null)
                {
                    await UserUnitOfWork.SetConnectionStringAsync(tenant.ConnectionString);
                    if (NewCat.MainCatName == null)
                        return BadRequest(Constants.Required_Field_ERROR_Response());

                    if (!await IsUniqeMainCat(NewCat.MainCatName))
                        return BadRequest(Constants.Unique_Field_ERROR_Response());

                    await UserUnitOfWork.ItemMainCategory.AddAsync(new ItemMainCategory { MainCatName = NewCat.MainCatName });
                    var result = await UserUnitOfWork.SaveAsync();
                    if (result > 0)
                    {
                        var Cats = await UserUnitOfWork.ItemMainCategory.GetAllAsync();
                        var addedCat = Cats.Last(x => x.MainCatName == NewCat.MainCatName);
                        await UserUnitOfWork.Item_SubCats.AddAsync(new ItemSubCategory
                        {
                            ItemMainCategoryId = addedCat.Id,
                            SubCatName = "Default Subcategory",

                        });
                        await UserUnitOfWork.SaveAsync();
                        return Ok(Cats.Last(x => x.MainCatName == NewCat.MainCatName));
                    }
                    return BadRequest(Constants.DataAddtion_ERROR_Response());
                }
                return BadRequest(Constants.NullTentant_Error_Response());
            }
            return BadRequest(Constants.HackTrying_Error_Response());
        }
        /************************************************
         * xxxxxxxxxxxxxxxxxxxx  Delete Main Categrory  xxxxxxxxxxxxxxxxxxxxx
         * (you need to get all items associated with this main cat and assign it to
         * uncategorized cat or user defined cat)
        *******************************************************/
        [HttpDelete("DelteItemMainCat")]
        [Authorize]
        [ValidateAntiForgeryTokenCustom]
        public async Task<IActionResult> ItemMainCategoryDelete(string Subdomain, int id)
        {
            if (CheckManuallyChanged_Subdomain(Subdomain))
            {
                //get tenant from TenantDP
                var Tenant = await TenantsUnitOfWork.Tenants.TenantBySubdomainAsync(Subdomain);
                if (Tenant != null)
                {
                    //if Tentnat is found, set the connection stirng
                    await UserUnitOfWork.SetConnectionStringAsync(Tenant.ConnectionString);
                    //Check if teh Main cat is found in DB
                    var MainCat = await UserUnitOfWork.ItemMainCategory.GetAsync(id);

                    if (MainCat != null)
                    {
                        if (MainCat.MainCatName == Constants.Uncategorized)
                        {
                            return BadRequest(Constants.Delete_Default_Error_Response());
                        }
                        /*xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                         * Get Items and update their CategoryId forign key
                         * to the uncategorized Id .... This done after implementing 
                         * the funcitons of Item. ..... Then delete and save changes
                         * xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx*/
                        UserUnitOfWork.ItemMainCategory.Remove(MainCat);
                        var result = await UserUnitOfWork.SaveAsync();
                        if (result > 0)
                        {
                            //If all conditions are success.
                            return Ok(Constants.Data_Deleted_SUCCESS_Response());
                        }
                        //If the Main Cat cat cannot be deleted
                        return BadRequest(Constants.Data_Deleted_ERROR_Response());
                    }
                    //If the tenant is not found
                    return BadRequest(Constants.Data_NOTFOUND_ERROR_Response());
                }
                return BadRequest(Constants.NullTentant_Error_Response());
            }
            return BadRequest(Constants.HackTrying_Error_Response());
        }
        //Update Main Cat 

        [HttpPut("UpdateItemMainCategory")]
        [Authorize]
        [ValidateAntiForgeryTokenCustom]
        public async Task<IActionResult> ItemMainCategory_Update(ItemMainCategory MainCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(Constants.ModelState_ERROR_Response(ModelState));
            }
            if (CheckManuallyChanged_Subdomain(MainCategory.Subdomain))
            {
                
                //get tenant from TenantDP
                var Tenant = await TenantsUnitOfWork.Tenants.TenantBySubdomainAsync(MainCategory.Subdomain);
                if (Tenant != null)
                {
                    //if Tentnat is found, set the connection stirng
                    await UserUnitOfWork.SetConnectionStringAsync(Tenant.ConnectionString);
                    //Check if teh Main cat is found in DB
                    var MainCat = await UserUnitOfWork.ItemMainCategory.GetAsync(MainCategory.Id);
                    
                    if (MainCat != null)
                    {
                        if (MainCat.MainCatName == Constants.Uncategorized)
                        {
                            return BadRequest(Constants.Delete_Default_Error_Response());
                        }
                        if (MainCat.MainCatName == MainCategory.MainCatName)
                            return StatusCode(200, new { status = Constants.SameObject });
                        if (!await IsUniqeMainCat(MainCategory.MainCatName))
                        {
                            return BadRequest(Constants.Unique_Field_ERROR_Response());
                        }
                        MainCat.MainCatName = MainCategory.MainCatName;
                        UserUnitOfWork.ItemMainCategory.Update(MainCat);
                        var result = await UserUnitOfWork.SaveAsync();
                        if (result > 0)
                            return Ok(Constants.Data_SAVED_SUCCESS_Response());
                        //If the Main cannot be deleted
                        return BadRequest(Constants.Data_SAVED_ERROR_Response());
                    }
                    //If the tenant is not found
                    return BadRequest(Constants.Data_NOTFOUND_ERROR_Response());
                }
                return BadRequest(Constants.NullTentant_Error_Response());
            }
            return BadRequest(Constants.HackTrying_Error_Response());
        }
        #endregion

        #region Item Subcats Category Functions
        //Get all Sub cats
        [HttpGet(nameof(GetItemsAllSubCategories))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<List<ItemSubCategory>>> GetItemsAllSubCategories(string subdomain)
        {
            if (CheckManuallyChanged_Subdomain(subdomain))
            {
                var tenant = await TenantsUnitOfWork.Tenants.TenantBySubdomainAsync(subdomain);
                if (tenant != null)
                {
                    await UserUnitOfWork.SetConnectionStringAsync(tenant.ConnectionString);
                    var SubCats = await UserUnitOfWork.Item_SubCats.GetAllAsync();
                    return Ok(SubCats);
                }
                return BadRequest(Constants.NullTentant_Error_Response());
            }
            return BadRequest(Constants.HackTrying_Error_Response());
        }
        [Authorize]
        [ValidateAntiForgeryTokenCustom]
        //Add new SubCat Cat
        [HttpPost(nameof(AddSubCategory))]
        public async Task<IActionResult> AddSubCategory([FromBody] ItemSubCategory NewSubCat)
        {
            if (!ModelState.IsValid)
                return BadRequest(Constants.ModelState_ERROR_Response(ModelState));
            if (CheckManuallyChanged_Subdomain(NewSubCat.Subdomain))
            {
                var tenant = await TenantsUnitOfWork.Tenants.TenantBySubdomainAsync(NewSubCat.Subdomain);
                if (tenant != null)
                {
                    await UserUnitOfWork.SetConnectionStringAsync(tenant.ConnectionString);
                    if (NewSubCat.SubCatName == null)
                        return BadRequest(Constants.Required_Field_ERROR_Response());
                    if (NewSubCat.ItemMainCategoryId == 0)
                        return BadRequest(Constants.NotSelected_MainCat_Error_Response());
                    if (!await IsUniqueSubCat_Per_MainCat(NewSubCat, NewSubCat.ItemMainCategoryId))
                        return BadRequest(Constants.NOT_Unique_SubCat_Per_MainCat_ERROR_Response());

                    await UserUnitOfWork.Item_SubCats.AddAsync(new ItemSubCategory
                    {
                        SubCatName = NewSubCat.SubCatName,
                        ItemMainCategoryId = NewSubCat.ItemMainCategoryId
                    });
                    var result = await UserUnitOfWork.SaveAsync();
                    if (result > 0)
                    {
                        var Cats = await UserUnitOfWork.Item_SubCats.GetAllAsync();
                        return Ok(Cats.Last(x => x.SubCatName == NewSubCat.SubCatName));
                    }
                    return BadRequest(Constants.DataAddtion_ERROR_Response());
                }
                return BadRequest(Constants.NullTentant_Error_Response());
            }
            return BadRequest(Constants.HackTrying_Error_Response());
        }

        //Update Sub Cat
        [HttpPut("UpdateItemSubCategory")]
        [Authorize]
        [ValidateAntiForgeryTokenCustom]
        public async Task<IActionResult> Item_Sub_CategoryUpdate(ItemSubCategory SubCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(Constants.ModelState_ERROR_Response(ModelState));
            }
            if (CheckManuallyChanged_Subdomain(SubCategory.Subdomain))
            {
                //get tenant from TenantDP
                var Tenant = await TenantsUnitOfWork.Tenants.TenantBySubdomainAsync(SubCategory.Subdomain);
                if (Tenant != null)
                {
                    //if Tentnat is found, set the connection stirng
                    await UserUnitOfWork.SetConnectionStringAsync(Tenant.ConnectionString);
                    //Check if the Main cat is found in DB
                    var SubCat = await UserUnitOfWork.Item_SubCats.GetAsync(SubCategory.Id);
                    if (SubCategory.ItemMainCategoryId == 0)
                        return BadRequest(Constants.NotSelected_MainCat_Error_Response());
                    if (SubCat.SubCatName == Constants.DefaultSubCategory)
                    {
                        return BadRequest(Constants.Delete_Default_Error_Response());
                    }
                    if (!await IsUniqueSubCat_Per_MainCat(SubCategory, SubCategory.ItemMainCategoryId))
                        return BadRequest(Constants.Unique_SubCat_Per_MainCat_ERROR_Response());
                    if (SubCat != null)
                    {
                        SubCat.SubCatName = SubCategory.SubCatName;
                        UserUnitOfWork.Item_SubCats.Update(SubCat);
                        var result = await UserUnitOfWork.SaveAsync();
                        if (result > 0)
                            return Ok(Constants.Data_SAVED_SUCCESS_Response());

                        //If the Main cannot be deleted
                        return BadRequest(Constants.Data_SAVED_ERROR_Response());
                    }
                    //If the tenant is not found
                    return BadRequest(Constants.Data_NOTFOUND_ERROR_Response());
                }
                return BadRequest(Constants.NullTentant_Error_Response());
            }
            return BadRequest(Constants.HackTrying_Error_Response());
        }

        //Delete
        [HttpDelete("DelteItemSubCat")]
        [Authorize]
        [ValidateAntiForgeryTokenCustom]
        public async Task<IActionResult> Item_Sub_CategoryDelete(string Subdomain, int id)
        {
            if (CheckManuallyChanged_Subdomain(Subdomain))
            {
                //get tenant from TenantDP
                var Tenant = await TenantsUnitOfWork.Tenants.TenantBySubdomainAsync(Subdomain);
                if (Tenant != null)
                {
                    //if Tentnat is found, set the connection stirng
                    await UserUnitOfWork.SetConnectionStringAsync(Tenant.ConnectionString);
                    //Check if teh Main cat is found in DB
                    var SubCat = await UserUnitOfWork.Item_SubCats.GetAsync(id);

                    if (SubCat != null)
                    {
                        if (SubCat.SubCatName == Constants.DefaultSubCategory)
                            return BadRequest(Constants.Delete_Default_Error_Response());
      
                        UserUnitOfWork.Item_SubCats.Remove(SubCat);
                        var result = await UserUnitOfWork.SaveAsync();
                        if (result > 0)
                        {
                            //If all conditions are success.
                            return Ok(Constants.Data_Deleted_SUCCESS_Response());
                        }
                        //If the Sub Cat cat cannot be deleted
                        return BadRequest(Constants.Data_Deleted_ERROR_Response());
                    }
                    //If the tenant is not found
                    return BadRequest(Constants.Data_NOTFOUND_ERROR_Response());
                }
                return BadRequest(Constants.NullTentant_Error_Response());
            }
            return BadRequest(Constants.HackTrying_Error_Response());
        }
        #endregion

        #region Units Functions
        //Get all Units
        [HttpGet("AllItemUnits")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<List<ItemSubCategory>>> GetAllUnits(string subdomain)
        {
            if (CheckManuallyChanged_Subdomain(subdomain))
            {
                var tenant = await TenantsUnitOfWork.Tenants.TenantBySubdomainAsync(subdomain);
                if (tenant != null)
                {
                    await UserUnitOfWork.SetConnectionStringAsync(tenant.ConnectionString);
                    var units = await UserUnitOfWork.ItemUnits.GetAllAsync();
                    return Ok(units);
                }
                return BadRequest(Constants.NullTentant_Error_Response());
            }
            return BadRequest(Constants.HackTrying_Error_Response());
        }
        //Add new Item Unit
        [HttpPost(nameof(AddItemUnit))]
        [Authorize]
        [ValidateAntiForgeryTokenCustom]
        public async Task<IActionResult> AddItemUnit([FromBody] Units Unit)
        {
            if (!ModelState.IsValid)
                return BadRequest(Constants.ModelState_ERROR_Response(ModelState));
            if (Unit.NumberInRetailSale == 0 || Unit.NumberInWholeSale == 0)
                return BadRequest(Constants.Required_Field_ERROR_Response());
            if (CheckManuallyChanged_Subdomain(Unit.Subdomain))
            {
                var tenant = await TenantsUnitOfWork.Tenants.TenantBySubdomainAsync(Unit.Subdomain);
                if (tenant != null)
                {
                    await UserUnitOfWork.SetConnectionStringAsync(tenant.ConnectionString);
                    if (Unit.WholeSaleUnit == null)
                        return BadRequest(Constants.Required_Field_ERROR_Response());
                    if (!await IsUniqe_ItemUnit(Unit.WholeSaleUnit))
                        return BadRequest(Constants.Unique_Field_ERROR_Response());
                    await UserUnitOfWork.ItemUnits.AddAsync(new Units
                    {
                        WholeSaleUnit = Unit.WholeSaleUnit,
                        RetailUnit = Unit.RetailUnit,
                        NumberInWholeSale = Unit.NumberInWholeSale,
                        NumberInRetailSale = Unit.NumberInRetailSale
                    });
                    var result = await UserUnitOfWork.SaveAsync();
                    if (result > 0)
                    {
                        var Units = await UserUnitOfWork.ItemUnits.GetAllAsync(x => x.WholeSaleUnit == Unit.WholeSaleUnit);
                        return Ok(Units.Last(x => x.WholeSaleUnit == Unit.WholeSaleUnit));
                    }
                    return BadRequest(Constants.DataAddtion_ERROR_Response());
                }
                return BadRequest(Constants.NullTentant_Error_Response());
            }
            return BadRequest(Constants.HackTrying_Error_Response());
        }

        //Update Item Unit
        [HttpPut("Update_Item_Unit")]
        [Authorize]
        [ValidateAntiForgeryTokenCustom]
        public async Task<IActionResult> Update_Item_Unit(Units Unit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(Constants.ModelState_ERROR_Response(ModelState));
            }
            if (CheckManuallyChanged_Subdomain(Unit.Subdomain))
            {
                //get tenant from TenantDP
                var Tenant = await TenantsUnitOfWork.Tenants.TenantBySubdomainAsync(Unit.Subdomain);
                if (Tenant != null)
                {
                    //if Tentnat is found, set the connection stirng
                    await UserUnitOfWork.SetConnectionStringAsync(Tenant.ConnectionString);
                    // Check if it is unique
                    if (!await IsUniqe_ItemUnit(Unit.WholeSaleUnit, Unit.Id))
                        return BadRequest(Constants.Unique_Field_ERROR_Response());
                    //Check if the unit is found in DB
                    var UnitFromDb = await UserUnitOfWork.ItemUnits.GetAsync(Unit.Id);
                    if (UnitFromDb != null)
                    {
                        UnitFromDb.WholeSaleUnit = Unit.WholeSaleUnit;
                        UnitFromDb.RetailUnit = Unit.RetailUnit;
                        UnitFromDb.NumberInWholeSale = Unit.NumberInWholeSale;
                        UnitFromDb.NumberInRetailSale = Unit.NumberInRetailSale;
                        UserUnitOfWork.ItemUnits.Update(UnitFromDb);
                        var result = await UserUnitOfWork.SaveAsync();
                        if (result > 0)
                            return Ok(Constants.Data_SAVED_SUCCESS_Response());

                        //If the Main cannot be deleted
                        return BadRequest(Constants.Data_SAVED_ERROR_Response());
                    }
                    //If the tenant is not found
                    return BadRequest(Constants.Data_NOTFOUND_ERROR_Response());
                }
                return BadRequest(Constants.NullTentant_Error_Response());
            }
            return BadRequest(Constants.HackTrying_Error_Response());
        }

        //Delete
        [HttpDelete("DelteItemUnit")]
        [Authorize]
        [ValidateAntiForgeryTokenCustom]
        public async Task<IActionResult> Delete_ItemUnit(string Subdomain, int id)
        {
            if (CheckManuallyChanged_Subdomain(Subdomain))
            {
                //get tenant from TenantDP
                var Tenant = await TenantsUnitOfWork.Tenants.TenantBySubdomainAsync(Subdomain);
                if (Tenant != null)
                {
                    //if Tentnat is found, set the connection stirng
                    await UserUnitOfWork.SetConnectionStringAsync(Tenant.ConnectionString);
                    //Check if teh Main cat is found in DB
                    var Unit = await UserUnitOfWork.ItemUnits.GetAsync(id);

                    if (Unit != null)
                    {
                        UserUnitOfWork.ItemUnits.Remove(Unit);
                        var result = await UserUnitOfWork.SaveAsync();
                        if (result > 0)
                        {
                            //If all conditions are success.
                            return Ok(Constants.Data_Deleted_SUCCESS_Response());
                        }
                        //If the Sub Cat cat cannot be deleted
                        return BadRequest(Constants.Data_Deleted_ERROR_Response());
                    }
                    //If the tenant is not found
                    return BadRequest(Constants.Data_NOTFOUND_ERROR_Response());
                }
                return BadRequest(Constants.NullTentant_Error_Response());
            }
            return BadRequest(Constants.HackTrying_Error_Response());
        }
        #endregion

        #region Item Brands Functions
        //Get all Brands
        [HttpGet(nameof(GetAllBrands))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<List<Brands>>> GetAllBrands(string subdomain)
        {
            if (CheckManuallyChanged_Subdomain(subdomain))
            {
                var tenant = await TenantsUnitOfWork.Tenants.TenantBySubdomainAsync(subdomain);
                if (tenant != null)
                {
                    await UserUnitOfWork.SetConnectionStringAsync(tenant.ConnectionString);
                    var Brands = await UserUnitOfWork.ItemBrands.GetAllAsync();
                    return Ok(Brands);
                }
                return BadRequest(Constants.NullTentant_Error_Response());
            }
            return BadRequest(Constants.HackTrying_Error_Response());
        }
        //Add new Brand
        [HttpPost(nameof(AddNewBrand))]
        [Authorize]
        [ValidateAntiForgeryTokenCustom]
        public async Task<IActionResult> AddNewBrand(Brands NewBrand)
        {
            if (CheckManuallyChanged_Subdomain(NewBrand.Subdomain))
            {
                var tenant = await TenantsUnitOfWork.Tenants.TenantBySubdomainAsync(NewBrand.Subdomain);
                if (tenant != null)
                {
                    await UserUnitOfWork.SetConnectionStringAsync(tenant.ConnectionString);
                    if (NewBrand.BrandName == null)
                        return BadRequest(Constants.Required_Field_ERROR_Response());

                    if (!await UserUnitOfWork.ItemBrands.IsUnique(x=>x.BrandName == NewBrand.BrandName))
                        return BadRequest(Constants.Unique_Field_ERROR_Response());

                    await UserUnitOfWork.ItemBrands.AddAsync(new Brands { BrandName = NewBrand.BrandName });
                    var result = await UserUnitOfWork.SaveAsync();
                    if (result > 0)
                    {
                        var Brands = await UserUnitOfWork.ItemBrands.GetAllAsync();
                        return Ok(Brands.Last(x => x.BrandName == NewBrand.BrandName));
                    }
                    return BadRequest(Constants.DataAddtion_ERROR_Response());
                }
                return BadRequest(Constants.NullTentant_Error_Response());
            }
            return BadRequest(Constants.HackTrying_Error_Response());
        }
        //Delete Brand
        [HttpDelete(nameof(DeleteBrand))]
        [Authorize]
        [ValidateAntiForgeryTokenCustom]
        public async Task<IActionResult> DeleteBrand(string Subdomain, int id)
        {
            if (CheckManuallyChanged_Subdomain(Subdomain))
            {
                //get tenant from TenantDP
                var Tenant = await TenantsUnitOfWork.Tenants.TenantBySubdomainAsync(Subdomain);
                if (Tenant != null)
                {
                    //if Tentnat is found, set the connection stirng
                    await UserUnitOfWork.SetConnectionStringAsync(Tenant.ConnectionString);
                    //Check if teh Main cat is found in DB
                    var Brand = await UserUnitOfWork.ItemBrands.GetAsync(id);

                    if (Brand != null)
                    {
                        UserUnitOfWork.ItemBrands.Remove(Brand);
                        var result = await UserUnitOfWork.SaveAsync();
                        if (result > 0)
                        {
                            //If all conditions are success.
                            return Ok(Constants.Data_Deleted_SUCCESS_Response());
                        }
                        //If the Main Cat cat cannot be deleted
                        return BadRequest(Constants.Data_Deleted_ERROR_Response());
                    }
                    //If the tenant is not found
                    return BadRequest(Constants.Data_NOTFOUND_ERROR_Response());
                }
                return BadRequest(Constants.NullTentant_Error_Response());
            }
            return BadRequest(Constants.HackTrying_Error_Response());
        }

        //Update Brand
        [HttpPut(nameof(UpdateBrand))]
        [Authorize]
        [ValidateAntiForgeryTokenCustom]
        public async Task<IActionResult> UpdateBrand(Brands Brand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(Constants.ModelState_ERROR_Response(ModelState));
            }
            if (CheckManuallyChanged_Subdomain(Brand.Subdomain))
            {
                //get tenant from TenantDP
                var Tenant = await TenantsUnitOfWork.Tenants.TenantBySubdomainAsync(Brand.Subdomain);
                if (Tenant != null)
                {
                    //if Tentnat is found, set the connection stirng
                    await UserUnitOfWork.SetConnectionStringAsync(Tenant.ConnectionString);
                    //Check if teh Main cat is found in DB
                    var BrandToUpdate = await UserUnitOfWork.ItemBrands.GetAsync(Brand.Id);
                    if (!await UserUnitOfWork.ItemBrands.IsUnique(x=>x.BrandName == Brand.BrandName))
                    {
                        return BadRequest(Constants.Unique_Field_ERROR_Response());
                    }
                    if (BrandToUpdate != null)
                    {
                        BrandToUpdate.BrandName = Brand.BrandName;
                        UserUnitOfWork.ItemBrands.Update(BrandToUpdate);
                        var result = await UserUnitOfWork.SaveAsync();
                        if (result > 0)
                            return Ok(Constants.Data_SAVED_SUCCESS_Response());
                        //If the Main cannot be deleted
                        return BadRequest(Constants.Data_SAVED_ERROR_Response());
                    }
                    //If the tenant is not found
                    return BadRequest(Constants.Data_NOTFOUND_ERROR_Response());
                }
                return BadRequest(Constants.NullTentant_Error_Response());
            }
            return BadRequest(Constants.HackTrying_Error_Response());
        }


        #endregion

        #region Items functions

        [HttpGet(nameof(GetAll_RequiredData))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<AllItemNeededData>> GetAll_RequiredData(string subomain)
        {
            if (CheckManuallyChanged_Subdomain(subomain))
            {
                var tenant = await TenantsUnitOfWork.Tenants.TenantBySubdomainAsync(subomain);
                if (tenant != null)
                {
                    await UserUnitOfWork.SetConnectionStringAsync(tenant.ConnectionString);

                    var AllRequiredData = new AllItemNeededData()
                    {
                        Brands = await UserUnitOfWork.ItemBrands.GetAllAsync(),
                        ItemMainCategories = UserUnitOfWork.ItemMainCategory.GetAllAsync(includeProperties: "ItemSubCategory").GetAwaiter().GetResult().ToList(),
                        Units = await UserUnitOfWork.ItemUnits.GetAllAsync(),
                        Suppliers = await UserUnitOfWork.Suppliers.GetAllAsync(),
                        ItemSKUKeys = await UserUnitOfWork.ItemSKUKeys.GetAllAsync()
                    };
                    return AllRequiredData;
                }
                return BadRequest(Constants.NullTentant_Error_Response());
            }
            return BadRequest(Constants.HackTrying_Error_Response());
        }

        [HttpGet(nameof(GetAllItems))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<List<Item>>> GetAllItems(string subomain)
        {
            if (CheckManuallyChanged_Subdomain(subomain))
            {
                var tenant = await TenantsUnitOfWork.Tenants.TenantBySubdomainAsync(subomain);
                if (tenant != null)
                {
                    await UserUnitOfWork.SetConnectionStringAsync(tenant.ConnectionString);
                    List<Item> items = UserUnitOfWork.Items.GetAllAsync(
                        includeProperties: "ItemNotes, ItemDescription, Item_Units, ItemBrands, Item_Per_Subcategory")
                        .GetAwaiter().GetResult().ToList();
                    foreach (var item in items)
                    {
                        item.ApplicationUser.PasswordHash = null;
                        item.Description = item.ItemDescription.Description;
                        item.NotesForClients = item.ItemNotes.Notes;
                        item.InternalNote = item.InternalNotes.Notes;
                    }
                    return items;
                }
                return BadRequest(Constants.NullTentant_Error_Response());
            }
            return BadRequest(Constants.HackTrying_Error_Response());
        }


        #endregion

        //............................ ItemSKU
        #region ItemSKU

        [HttpGet(nameof(GetAll_ItemSKUKeys))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<List<ItemSKUKeys>>> GetAll_ItemSKUKeys(string subomain)
        {
            if (CheckManuallyChanged_Subdomain(subomain))
            {
                var tenant = await TenantsUnitOfWork.Tenants.TenantBySubdomainAsync(subomain);
                if (tenant != null)
                {
                    await UserUnitOfWork.SetConnectionStringAsync(tenant.ConnectionString);
                    var itemSKUKeys = await UserUnitOfWork.ItemSKUKeys.GetAllAsync();
                    
                    return itemSKUKeys;
                }
                return BadRequest(Constants.NullTentant_Error_Response());
            }
            return BadRequest(Constants.HackTrying_Error_Response());
        }

        #endregion
        //HelperMedthod       
        private bool CheckManuallyChanged_Subdomain(string subdomain)
        {
            return subdomain == HttpContext.Request.Host.Host.Split('.')[0];
        }

        public async Task<bool> IsUniqeMainCat(string catName)
        {
            var allCats = await UserUnitOfWork.ItemMainCategory.GetAllAsync();
            return allCats.Find(x => x.MainCatName == catName) == null;
        }
        public async Task<bool> IsUniqBrand(string BrandName)
        {
            var AllBrands = await UserUnitOfWork.ItemBrands.GetAllAsync();
            return AllBrands.Find(x => x.BrandName == BrandName) == null;
        }
        public async Task<bool> IsUniqe_ItemUnit(string Wholesale, int id = 0)
        {
            var AllUnits = await UserUnitOfWork.ItemUnits.GetAllAsync();
            if (id == 0)
                return AllUnits.Find(x => x.WholeSaleUnit == Wholesale) == null;
            var OtherUnits = AllUnits.Where(x => x.Id != id).ToList();
            return OtherUnits.Find(x => x.WholeSaleUnit == Wholesale) == null;
        }

        public async Task<bool> IsUniqueSubCat_Per_MainCat(ItemSubCategory newSubCat, int MainCatId)
        {
            var AllSubCat = await UserUnitOfWork.Item_SubCats.GetAllAsync(x => x.ItemMainCategoryId==MainCatId);
            foreach (var subcat in AllSubCat)
            {
                if (subcat.SubCatName == newSubCat.SubCatName) return false;
            }
            return true;
        }
    }
}
