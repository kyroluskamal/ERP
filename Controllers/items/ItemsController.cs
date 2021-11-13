using ERP.Controllers.Models;
using ERP.Data;
using ERP.Data.Identity;
using ERP.Models.Items;
using ERP.UnitOfWork;
using ERP.Utilities;
using ERP.Utilities.Services;
using ERP.Utilities.Services.EmailService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ERP.Controllers.items
{
    [Route("api/[controller]")]
    [ApiController]
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
           IUnitOfWork_Tenants tenantsUnitOfWork, ApplicationUserSignIngManager signinManager, IMailService mailService, ApplicationUserRoleManager roleManager)
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
        public async Task<ActionResult<List<ItemMainCategory>>> GetItemGategories(string subomain)
        {
            if (CheckManuallyChanged_Subdomain(subomain))
            {
                var tenant = await TenantsUnitOfWork.Tenants.TenantBySubdomainAsync(subomain);
                if (tenant != null)
                {
                    await UserUnitOfWork.SetConnectionStringAsync(tenant.ConnectionString);
                    return await UserUnitOfWork.ItemMainCategory.GetAllAsync();
                }
                return BadRequest(new { status = Constants.NullTenant_statuCode, error = Constants.NullTenant_ErrorMessage });
            }
            return BadRequest(new { status = Constants.HackTrying_Error, error = Constants.HackTrying_Error_message });
        }
        //Add new Main Cat
        [HttpGet(nameof(AddMainGategory))]
        public async Task<IActionResult> AddMainGategory(string catName, string subdomain)
        {
            if (CheckManuallyChanged_Subdomain(subdomain))
            {
                var tenant = await TenantsUnitOfWork.Tenants.TenantBySubdomainAsync(subdomain);
                if (tenant != null)
                {
                    await UserUnitOfWork.SetConnectionStringAsync(tenant.ConnectionString);
                    if (catName == null)
                    {
                        return BadRequest(new { status = Constants.Required_field, error = Constants.Required_field_ErrorMessage });
                    }

                    if (await NotUniqeMainCat(catName))
                    {
                        return BadRequest(new { status = Constants.Unique_Field_ERROR_Status, error = Constants.Unique_Field_ERROR_Message });
                    }
                    await UserUnitOfWork.ItemMainCategory.AddAsync(new ItemMainCategory { Name = catName });
                    var result = await UserUnitOfWork.SaveAsync();
                    if (result > 0)
                    {
                        var Cats = await UserUnitOfWork.ItemMainCategory.GetAllAsync();
                        return Ok(Cats.Last(x => x.Name == catName));
                    }
                    return BadRequest(new { status = Constants.DataAddtionStatus_Error_status, error = Constants.DataAddtionStatus_ERROR_ErrorMessage });
                }
                return BadRequest(new { status = Constants.NullTenant_statuCode, error = Constants.NullTenant_ErrorMessage });
            }
            return BadRequest(new { status = Constants.HackTrying_Error, error = Constants.HackTrying_Error_message });
        }
        /************************************************
         * xxxxxxxxxxxxxxxxxxxx  Delete Main Categrory  xxxxxxxxxxxxxxxxxxxxx
         * (you need to get all items associated with this main cat and assign it to
         * uncategorized cat or user defined cat)
        *******************************************************/
        [HttpDelete("DelteItemMainCat")]
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
                            return BadRequest(new { status = Constants.UnCategorized_Can_tDeleted_Or_Updated_Status, error = Constants.UnCategorized_Can_tDeleted_Or_Updated_Error_Message });
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
                            return Ok(new { status = Constants.Data_Deleted_success_status, message = Constants.Data_Deleted_success_message });
                        }
                        //If the Main cat cannot be deleted
                        return BadRequest(new { status = Constants.Data_Deleted_ERROR_status, error = Constants.Data_Deleted_ERROR_ErrorMessage });
                    }
                    //If the tenant is not found
                    return BadRequest(new { status = Constants.Data_NOTFOUND_ERROR_status, error = Constants.Data_NOTFOUND_ERROR_ErrorMessage });
                }
                return BadRequest(new { status = Constants.NullTenant_statuCode, error = Constants.NullTenant_ErrorMessage });
            }
            return BadRequest(new { status = Constants.HackTrying_Error, error = Constants.HackTrying_Error_message });
        }
        //Update Main Cat xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

        [HttpPut("UpdateItemMainCategory")]
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
                    return BadRequest(new { status = Constants.UnCategorized_Can_tDeleted_Or_Updated_Status, error = Constants.UnCategorized_Can_tDeleted_Or_Updated_Error_Message });
                }
                //get tenant from TenantDP
                var Tenant = await TenantsUnitOfWork.Tenants.TenantBySubdomainAsync(MainCategory.Subdomain);
                if (Tenant != null)
                {
                    //if Tentnat is found, set the connection stirng
                    await UserUnitOfWork.SetConnectionStringAsync(Tenant.ConnectionString);
                    //Check if teh Main cat is found in DB
                    var MainCat = await UserUnitOfWork.ItemMainCategory.GetAsync(MainCategory.Id);
                    if (await NotUniqeMainCat(MainCategory.Name))
                    {
                        return BadRequest(new { status = Constants.Unique_Field_ERROR_Status, error = Constants.Unique_Field_ERROR_Message });
                    }
                    if (MainCat != null)
                    {
                        MainCat.Name = MainCategory.Name;
                        UserUnitOfWork.ItemMainCategory.Update(MainCat);
                        var result = await UserUnitOfWork.SaveAsync();
                        if (result > 0)
                        {
                            return Ok(new { status = Constants.Data_Saved_success_status, message = Constants.Data_Saved_success_message });
                        }
                        //If the Main cannot be deleted
                        return BadRequest(new { status = Constants.Data_SAVED_ERROR_status, error = Constants.Data_Saved_Error_Message });
                    }
                    //If the tenant is not found
                    return BadRequest(new { status = Constants.Data_NOTFOUND_ERROR_status, error = Constants.Data_NOTFOUND_ERROR_ErrorMessage });
                }
                return BadRequest(new { status = Constants.NullTenant_statuCode, error = Constants.NullTenant_ErrorMessage });
            }
            return BadRequest(new { status = Constants.HackTrying_Error, error = Constants.HackTrying_Error_message });
        }
        #endregion

        #region Item Subcats Category Functions
        //Get all cats
        [HttpGet("allcategories")]
        public async Task<ActionResult<List<ItemSubCategory>>> GetSubCatsByMainItemId(ItemMainCategory MainCat)
        {
            if (CheckManuallyChanged_Subdomain(MainCat.Subdomain))
            {
                var tenant = await TenantsUnitOfWork.Tenants.TenantBySubdomainAsync(MainCat.Subdomain);
                if (tenant != null)
                {
                    await UserUnitOfWork.SetConnectionStringAsync(tenant.ConnectionString);
                    return await UserUnitOfWork.Item_SubCats.GetSubCats_By_MainCat_Id_Async(MainCat.Id);
                }
                return BadRequest(new { status = Constants.NullTenant_statuCode, error = Constants.NullTenant_ErrorMessage });
            }
            return BadRequest(new { status = Constants.HackTrying_Error, error = Constants.HackTrying_Error_message });
        }
        #endregion
        //HelperMedthod
        private bool CheckManuallyChanged_Subdomain(string subdomain)
        {
            return subdomain == HttpContext.Request.Host.Host.Split('.')[0];
        }

        private async Task<bool> NotUniqeMainCat(string catName)
        {
            var allCats = await UserUnitOfWork.ItemMainCategory.GetAllAsync();
            return allCats.Find(x => x.Name == catName) != null;
        }
    }
}
