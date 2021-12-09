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
using ERP.Models.Supplier;

namespace ERP.Controllers.Supply
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
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

        public SuppliersController(ApplicationUserManager userManager, ITokenService tokenService, Constants constants,
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

        #region Inventories functions
        //Get all cats
        [HttpGet("AllSuppliers")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<List<Suppliers>>> GetAllSupliers(string subomain)
        {
            if (CheckManuallyChanged_Subdomain(subomain))
            {
                var tenant = await TenantsUnitOfWork.Tenants.TenantBySubdomainAsync(subomain);
                if (tenant != null)
                {
                    await UserUnitOfWork.SetConnectionStringAsync(tenant.ConnectionString);
                    return await UserUnitOfWork.Suppliers.GetAllAsync();
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
    }
}
