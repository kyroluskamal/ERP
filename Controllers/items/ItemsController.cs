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
            var tenant = await TenantsUnitOfWork.Tenants.TenantBySubdomainAsync(subomain);
            if (tenant != null)
            {
                await UserUnitOfWork.SetConnectionStringAsync(tenant.ConnectionString);
                return await UserUnitOfWork.ItemMainCategory.GetAllAsync();
            }
            return BadRequest(new { status = Constants.NullTenant_statuCode, error = Constants.NullTenant_ErrorMessage });
        }
        //Add new Main Cat
        [HttpGet(nameof(AddMainGategory))]
        public async Task<IActionResult> AddMainGategory(string catName, string subdomain)
        {
            var tenant = await TenantsUnitOfWork.Tenants.TenantBySubdomainAsync(subdomain);
            Debug.WriteLine(tenant.ConnectionString);
            if (tenant != null)
            {
                await UserUnitOfWork.SetConnectionStringAsync(tenant.ConnectionString);
                if (catName == null)
                {
                    return BadRequest(new { status = Constants.Required_field, error = Constants.Required_field_ErrorMessage });
                }
                await UserUnitOfWork.ItemMainCategory.AddAsync(new ItemMainCategory { Name = catName });
                var result = await UserUnitOfWork.SaveAsync();
                if (result > 0)
                {
                    var Cats = await UserUnitOfWork.ItemMainCategory.GetAllAsync();
                    return Ok(Cats.Last(x => x.Name == catName));
                }
                return BadRequest(new { status = Constants.Can_Not_Save_To_Db, error = Constants.Can_Not_Save_To_Db_ErrorMessage });
            }
            return BadRequest(new { status = Constants.NullTenant_statuCode, error = Constants.NullTenant_ErrorMessage });
        }
        /************************************************
         * xxxxxxxxxxxxxxxxxxxx  Delete Main Categrory  xxxxxxxxxxxxxxxxxxxxx
         * (you need to get all items associated with this main cat and assign it to
         * uncategorized cat or user defined cat)
        *******************************************************/

        //Update Main Cat xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        #endregion
    }
}
