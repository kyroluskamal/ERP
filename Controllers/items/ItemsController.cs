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
                    return await UserUnitOfWork.ItemMainCategory.GetAllAsync();
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
                    if (NewCat.Name == null)
                        return BadRequest(Constants.Required_Field_ERROR_Response());

                    if (!await IsUniqeMainCat(NewCat.Name))
                        return BadRequest(Constants.Unique_Field_ERROR_Response());

                    await UserUnitOfWork.ItemMainCategory.AddAsync(new ItemMainCategory { Name = NewCat.Name });
                    var result = await UserUnitOfWork.SaveAsync();
                    if (result > 0)
                    {
                        var Cats = await UserUnitOfWork.ItemMainCategory.GetAllAsync();
                        return Ok(Cats.Last(x => x.Name == NewCat.Name));
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
                        if (MainCat.Name == Constants.Uncategorized)
                        {
                            return BadRequest(Constants.Uncategorized_Delete_ERROR_Response());
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
                return BadRequest(new { status = Constants.ModelState_statuCode, error = ModelState });
            }
            if (CheckManuallyChanged_Subdomain(MainCategory.Subdomain))
            {
                if (MainCategory.Name == Constants.Uncategorized)
                {
                    return BadRequest(Constants.Uncategorized_Delete_ERROR_Response());
                }
                //get tenant from TenantDP
                var Tenant = await TenantsUnitOfWork.Tenants.TenantBySubdomainAsync(MainCategory.Subdomain);
                if (Tenant != null)
                {
                    //if Tentnat is found, set the connection stirng
                    await UserUnitOfWork.SetConnectionStringAsync(Tenant.ConnectionString);
                    //Check if teh Main cat is found in DB
                    var MainCat = await UserUnitOfWork.ItemMainCategory.GetAsync(MainCategory.Id);
                    if (!await IsUniqeMainCat(MainCategory.Name))
                    {
                        return BadRequest(Constants.Unique_Field_ERROR_Response());
                    }
                    if (MainCat != null)
                    {
                        MainCat.Name = MainCategory.Name;
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
                return BadRequest(new { status = Constants.NotSelected_MainCat_ERROR_status, error = Constants.NotSelected_MainCat_ERROR_Message });
            if (CheckManuallyChanged_Subdomain(NewSubCat.Subdomain))
            {

                var tenant = await TenantsUnitOfWork.Tenants.TenantBySubdomainAsync(NewSubCat.Subdomain);
                if (tenant != null)
                {
                    await UserUnitOfWork.SetConnectionStringAsync(tenant.ConnectionString);
                    if (NewSubCat.Name == null)
                        return BadRequest(Constants.Required_Field_ERROR_Response());

                    if (!await IsUniqueSubCat_Per_MainCat(NewSubCat))
                        return BadRequest(Constants.NOT_Unique_SubCat_Per_MainCat_ERROR_Response());

                    await UserUnitOfWork.Item_SubCats.AddAsync(new ItemSubCategory
                    {
                        Name = NewSubCat.Name,
                        ItemMainCategoryId = NewSubCat.ItemMainCategoryId
                    });
                    var result = await UserUnitOfWork.SaveAsync();
                    if (result > 0)
                    {
                        var Cats = await UserUnitOfWork.Item_SubCats.GetAllAsync();
                        return Ok(Cats.Last(x => x.Name == NewSubCat.Name));
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
                    //Check if teh Main cat is found in DB
                    var SubCat = await UserUnitOfWork.Item_SubCats.GetAsync(SubCategory.Id);
                    if (!await IsUniqueSubCat_Per_MainCat(SubCategory))
                        return BadRequest(Constants.Unique_SubCat_Per_MainCat_ERROR_Response());
                    if (SubCat != null)
                    {
                        SubCat.Name = SubCategory.Name;
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
                    if (NewBrand.Name == null)
                        return BadRequest(Constants.Required_Field_ERROR_Response());

                    if (!await UserUnitOfWork.ItemBrands.IsUnique(x=>x.Name == NewBrand.Name))
                        return BadRequest(Constants.Unique_Field_ERROR_Response());

                    await UserUnitOfWork.ItemBrands.AddAsync(new Brands { Name = NewBrand.Name });
                    var result = await UserUnitOfWork.SaveAsync();
                    if (result > 0)
                    {
                        var Brands = await UserUnitOfWork.ItemBrands.GetAllAsync();
                        return Ok(Brands.Last(x => x.Name == NewBrand.Name));
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
                    if (!await UserUnitOfWork.ItemBrands.IsUnique(x=>x.Name == Brand.Name))
                    {
                        return BadRequest(Constants.Unique_Field_ERROR_Response());
                    }
                    if (BrandToUpdate != null)
                    {
                        BrandToUpdate.Name = Brand.Name;
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

        [HttpGet(nameof(GetAllItems))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<List<Inventories>>> GetAllItems(string subomain)
        {
            if (CheckManuallyChanged_Subdomain(subomain))
            {
                var tenant = await TenantsUnitOfWork.Tenants.TenantBySubdomainAsync(subomain);
                if (tenant != null)
                {
                    await UserUnitOfWork.SetConnectionStringAsync(tenant.ConnectionString);
                    var inventories = await UserUnitOfWork.Inventories.GetAllAsync();
                    foreach (var invent in inventories)
                    {
                        invent.InventoryAddress = await UserUnitOfWork.InventoryAddress.GetFirstOrDefaultAsync(x => x.InventoriesId == invent.Id);
                    }
                    return inventories;
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
            return allCats.Find(x => x.Name == catName) == null;
        }
        public async Task<bool> IsUniqBrand(string BrandName)
        {
            var AllBrands = await UserUnitOfWork.ItemBrands.GetAllAsync();
            return AllBrands.Find(x => x.Name == BrandName) == null;
        }
        public async Task<bool> IsUniqe_ItemUnit(string Wholesale, int id = 0)
        {
            var AllUnits = await UserUnitOfWork.ItemUnits.GetAllAsync();
            if (id == 0)
                return AllUnits.Find(x => x.WholeSaleUnit == Wholesale) == null;
            var OtherUnits = AllUnits.Where(x => x.Id != id).ToList();
            return OtherUnits.Find(x => x.WholeSaleUnit == Wholesale) == null;
        }

        public async Task<bool> IsUniqueSubCat_Per_MainCat(ItemSubCategory newSubCat)
        {
            var AllSubCat = await UserUnitOfWork.Item_SubCats.GetAllAsync();
            var SubCats_per_MainCat = AllSubCat.Where(x => x.ItemMainCategoryId == newSubCat.ItemMainCategory.Id).ToArray();
            foreach (var subcat in SubCats_per_MainCat)
            {
                if (subcat.Name == newSubCat.Name) return false;
            }
            return true;
        }
    }
}
