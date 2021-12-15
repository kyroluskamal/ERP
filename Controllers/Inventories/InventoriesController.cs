using ERP.Data;
using ERP.Data.Identity;
using ERP.Models.Inventory;
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
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ERP.Controllers.Inventory
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors(PolicyName = "AllowOrigin")]
    public class InventoriesController : ControllerBase
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

        public InventoriesController(ApplicationUserManager userManager, ITokenService tokenService, Constants constants,
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
        [HttpGet("AllInventories")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<List<Inventories>>> GetAllInventories(string subomain)
        {
            if (CheckManuallyChanged_Subdomain(subomain))
            {
                var tenant = await TenantsUnitOfWork.Tenants.TenantBySubdomainAsync(subomain);
                if (tenant != null)
                {
                    await UserUnitOfWork.SetConnectionStringAsync(tenant.ConnectionString);
                    return UserUnitOfWork.Inventories.GetAllAsync(includeProperties: "InventoryAddress").GetAwaiter().GetResult().ToList();
                }
                return BadRequest(Constants.NullTentant_Error_Response());
            }
            return BadRequest(Constants.HackTrying_Error_Response());
        }

        //Add new Item Unit
        [HttpPost(nameof(AddWarehouse))]
        [Authorize]
        [ValidateAntiForgeryTokenCustom]
        public async Task<IActionResult> AddWarehouse([FromBody] Inventories Inventory)
        {
            if (!ModelState.IsValid)
                return BadRequest(Constants.ModelState_ERROR_Response(ModelState));

            if (CheckManuallyChanged_Subdomain(Inventory.Subdomain))
            {
                var tenant = await TenantsUnitOfWork.Tenants.TenantBySubdomainAsync(Inventory.Subdomain);
                if (tenant != null)
                {
                    await UserUnitOfWork.SetConnectionStringAsync(tenant.ConnectionString);

                    if (!await UserUnitOfWork.Inventories.IsUnique(x=>x.WarehouseName == Inventory.WarehouseName))
                        return BadRequest(Constants.Unique_Field_ERROR_Response());
                    await UserUnitOfWork.Inventories.AddAsync(new Inventories
                    {
                        WarehouseName = Inventory.WarehouseName,
                        MobilePhone = Inventory.MobilePhone,
                        Telephone = Inventory.Telephone,
                        Notes= Inventory.Notes,
                        IsActive = Inventory.IsActive,
                        IsMainInventory = Inventory.IsMainInventory,
                        AddedBy_UserId = Inventory.AddedBy_UserId,
                        AddedBy_UserName = Inventory.AddedBy_UserName
                    });
                    var result = await UserUnitOfWork.SaveAsync();
                    if (result > 0)
                    {
                        var Units = await UserUnitOfWork.Inventories.GetAllAsync(x => x.WarehouseName == Inventory.WarehouseName);
                        return Ok(Units.Last(x => x.WarehouseName == Inventory.WarehouseName));
                    }
                    return BadRequest(Constants.DataAddtion_ERROR_Response());
                }
                return BadRequest(Constants.NullTentant_Error_Response());
            }
            return BadRequest(Constants.HackTrying_Error_Response());
        }
        //Update Inventory (warehouse)
        [HttpPut(nameof(Update_Warehouse))]
        [Authorize]
        [ValidateAntiForgeryTokenCustom]
        public async Task<IActionResult> Update_Warehouse(Inventories Inventory)
        {
            if (!ModelState.IsValid)
                return BadRequest(Constants.ModelState_ERROR_Response(ModelState));
           
            if (CheckManuallyChanged_Subdomain(Inventory.Subdomain))
            {
                //get tenant from TenantDP
                var Tenant = await TenantsUnitOfWork.Tenants.TenantBySubdomainAsync(Inventory.Subdomain);
                if (Tenant != null)
                {
                    //if Tentnat is found, set the connection stirng
                    await UserUnitOfWork.SetConnectionStringAsync(Tenant.ConnectionString);
                    // Check if it is unique
                    if (!await UserUnitOfWork.Inventories.IsUnique(x=>x.WarehouseName == Inventory.WarehouseName && x.Id!=Inventory.Id))
                        return BadRequest(Constants.Unique_Field_ERROR_Response());
                    //Check if the unit is found in DB
                    var InventoryFromDb = await UserUnitOfWork.Inventories.GetAsync(Inventory.Id);
                    if (InventoryFromDb != null)
                    {
                        InventoryFromDb.WarehouseName = Inventory.WarehouseName;
                        InventoryFromDb.MobilePhone = Inventory.MobilePhone;
                        InventoryFromDb.IsMainInventory = Inventory.IsMainInventory;
                        InventoryFromDb.Telephone = Inventory.Telephone;
                        InventoryFromDb.IsActive = Inventory.IsActive;
                        InventoryFromDb.Notes = Inventory.Notes;
                        
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
        [HttpDelete(nameof(DeleteWarehouse))]
        [Authorize]
        [ValidateAntiForgeryTokenCustom]
        public async Task<IActionResult> DeleteWarehouse(string Subdomain, int id)
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
                    var Inventory = await UserUnitOfWork.Inventories.GetAsync(id);

                    if (Inventory != null)
                    {
                        if (Inventory.WarehouseName == "Main warehouse")
                            return BadRequest(Constants.Delete_Default_inventory_Error_Response());
                        UserUnitOfWork.Inventories.Remove(Inventory);
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

        //HelperMedthod
        private bool CheckManuallyChanged_Subdomain(string subdomain)
        {
            return subdomain == HttpContext.Request.Host.Host.Split('.')[0];
        }
    }
}
