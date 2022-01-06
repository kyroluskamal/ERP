using ERP.Areas.Tenants.Models;
using ERP.Data;
using ERP.Data.Identity;
using ERP.Models.Inventory;
using ERP.UnitOfWork;
using ERP.Utilities;
using ERP.Utilities.Helpers;
using ERP.Utilities.Services;
using ERP.Utilities.Services.EmailService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
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
                    
                    List<InventoryAddress> InventAddresses = await UserUnitOfWork.InventoryAddress.GetAllAsync();
                    List<Inventories> inventories = UserUnitOfWork.Inventories.GetAllAsync(includeProperties:"InventoryAddress").GetAwaiter().GetResult().ToList();
                    List<int> inventIds = new List<int>();

                    return inventories;
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

                    if (!await UserUnitOfWork.Inventories.IsUnique(x => x.WarehouseName == Inventory.WarehouseName))
                        return BadRequest(Constants.Unique_Field_ERROR_Response());
                    await UserUnitOfWork.Inventories.AddAsync(new Inventories
                    {
                        WarehouseName = Inventory.WarehouseName,
                        MobilePhone = Inventory.MobilePhone,
                        Telephone = Inventory.Telephone,
                        Notes = Inventory.Notes,
                        IsActive = Inventory.IsActive,
                        IsMainInventory = Inventory.IsMainInventory,
                        AddedBy_UserId = Inventory.AddedBy_UserId,
                        AddedBy_UserName = Inventory.AddedBy_UserName
                    });
                    var result = await UserUnitOfWork.SaveAsync();
                    if (result > 0)
                    {
                        var inevntories = await UserUnitOfWork.Inventories.GetAllAsync(x => x.WarehouseName == Inventory.WarehouseName);
                        
                        return Ok(inevntories.Last(x => x.WarehouseName == Inventory.WarehouseName));
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
                    var InventoryFromDb = await UserUnitOfWork.Inventories.GetAsync(Inventory.Id);
                    if (InventoryFromDb.WarehouseName == Constants.MainWarehouse)
                        return BadRequest(Constants.Delete_Default_inventory_Error_Response());
                    // Check if it is unique
                    if (!await UserUnitOfWork.Inventories.IsUnique(x => x.WarehouseName == Inventory.WarehouseName
                            && x.Id != Inventory.Id))
                        return BadRequest(Constants.Unique_Field_ERROR_Response());
                    //Check if the unit is found in DB
                    
                    if (InventoryFromDb != null)
                    {
                        if (Inventory.WarehouseName == Constants.MainWarehouse)
                            return BadRequest(Constants.Delete_Default_inventory_Error_Response());
                        if (InventoryFromDb.WarehouseName == Inventory.WarehouseName
                        &&InventoryFromDb.MobilePhone == Inventory.MobilePhone
                        && InventoryFromDb.IsMainInventory == Inventory.IsMainInventory
                        && InventoryFromDb.Telephone == Inventory.Telephone
                        && InventoryFromDb.IsActive == Inventory.IsActive
                        && InventoryFromDb.Notes == Inventory.Notes) 
                            return StatusCode(200, new {status=Constants.SameObject});

                        InventoryFromDb.WarehouseName = Inventory.WarehouseName;
                        InventoryFromDb.MobilePhone = Inventory.MobilePhone;
                        InventoryFromDb.IsMainInventory = Inventory.IsMainInventory;
                        InventoryFromDb.Telephone = Inventory.Telephone;
                        InventoryFromDb.IsActive = Inventory.IsActive;
                        InventoryFromDb.Notes = Inventory.Notes;

                        var result = await UserUnitOfWork.SaveAsync();
                        if (result > 0)
                            return Ok(Constants.Data_SAVED_SUCCESS_Response());

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
                        if (Inventory.WarehouseName == Constants.MainWarehouse)
                            return BadRequest(Constants.Delete_Default_inventory_Error_Response());
                        UserUnitOfWork.Inventories.Remove(Inventory);
                        int result = await UserUnitOfWork.SaveAsync();
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

        #region InventoryAddress

        [HttpGet(nameof(GetAllAddresses))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<List<InventoryAddress>>> GetAllAddresses(string subomain)
        {
            if (CheckManuallyChanged_Subdomain(subomain))
            {
                var tenant = await TenantsUnitOfWork.Tenants.TenantBySubdomainAsync(subomain);
                if (tenant != null)
                {
                    await UserUnitOfWork.SetConnectionStringAsync(tenant.ConnectionString);
                    List<InventoryAddress> inventoryAddresses = await UserUnitOfWork.InventoryAddress.GetAllAsync();

                    return inventoryAddresses;
                }
                return BadRequest(Constants.NullTentant_Error_Response());
            }
            return BadRequest(Constants.HackTrying_Error_Response());
        }

        [HttpPost(nameof(AddAddress))]
        [Authorize]
        [ValidateAntiForgeryTokenCustom]
        public async Task<IActionResult> AddAddress(InventoryAddress address) 
        {
            if (!ModelState.IsValid)
                return BadRequest(Constants.ModelState_ERROR_Response(ModelState));
            if (CheckManuallyChanged_Subdomain(address.Subdomain))
            {
                TenantsInfo tenant = await TenantsUnitOfWork.Tenants.TenantBySubdomainAsync(address.Subdomain);
                if (tenant != null)
                {
                    await UserUnitOfWork.SetConnectionStringAsync(tenant.ConnectionString);

                    await UserUnitOfWork.InventoryAddress.AddAsync(new InventoryAddress {
                        AddressLine_1 = address.AddressLine_1,
                        AddressLine_2 = address.AddressLine_2,
                        PostalCode = address.PostalCode,
                        BuildingNo = address.BuildingNo,
                        FlatNo = address.FlatNo,
                        StreetName = address.StreetName,
                        City =address.City,
                        CountryName = address.CountryName,
                        CountryNameCode = address.CountryNameCode,
                        CountryId = address.CountryId,
                        Government = address.Government,
                        InventoriesId = address.InventoriesId
                    }); ;

                    int result = await UserUnitOfWork.SaveAsync();
                    if (result > 0)
                    {
                        return Ok(await UserUnitOfWork.InventoryAddress.GetFirstOrDefaultAsync(
                            x=>x.InventoriesId == address.InventoriesId));
                    }
                    return BadRequest(Constants.DataAddtion_ERROR_Response());
                }
                else return BadRequest(Constants.NullTentant_Error_Response());
            }
            return BadRequest(Constants.HackTrying_Error_Response());
        }
        [HttpDelete(nameof(DeleteAddress))]
        [Authorize]
        [ValidateAntiForgeryTokenCustom]
        public async Task<IActionResult> DeleteAddress(string Subdomain, int Id)
        {
            if (CheckManuallyChanged_Subdomain(Subdomain))
            {
                TenantsInfo Tenant = await TenantsUnitOfWork.Tenants.TenantBySubdomainAsync(Subdomain);
                if (Tenant != null)
                {
                    await UserUnitOfWork.SetConnectionStringAsync(Tenant.ConnectionString);
                    InventoryAddress addressToDelete = await UserUnitOfWork.InventoryAddress.GetAsync(Id);
                    if(addressToDelete != null)
                    {
                        await UserUnitOfWork.InventoryAddress.RemoveAsync(addressToDelete.Id);
                        int result = await UserUnitOfWork.SaveAsync();
                        if (result > 0)
                        {
                            return Ok(Constants.Data_Deleted_SUCCESS_Response());
                        } 
                        return BadRequest(Constants.Data_Deleted_ERROR_Response());
                    }
                    return BadRequest(Constants.Data_NOTFOUND_ERROR_Response());
                }
                return BadRequest(Constants.NullTentant_Error_Response());
            }
            return BadRequest(Constants.HackTrying_Error_Response());
        }

        [HttpPut(nameof(UpdateAddress))]
        [Authorize]
        [ValidateAntiForgeryTokenCustom]
        public async Task<IActionResult> UpdateAddress(InventoryAddress address)
        {
            if (!ModelState.IsValid)
                return BadRequest(Constants.ModelState_ERROR_Response(ModelState));

            if (CheckManuallyChanged_Subdomain(address.Subdomain))
            {
                //get tenant from TenantDP
                var Tenant = await TenantsUnitOfWork.Tenants.TenantBySubdomainAsync(address.Subdomain);
                if (Tenant != null)
                {
                    //if Tentnat is found, set the connection stirng
                    await UserUnitOfWork.SetConnectionStringAsync(Tenant.ConnectionString);
                   
                    //Check if the unit is found in DB
                    InventoryAddress AddressFromDb = await UserUnitOfWork.InventoryAddress.GetAsync(address.Id);

                    if (AddressFromDb != null)
                    {
                        if (AddressFromDb.BuildingNo == address.BuildingNo
                        && AddressFromDb.FlatNo == address.FlatNo
                        && AddressFromDb.AddressLine_1 == address.AddressLine_1
                        && AddressFromDb.AddressLine_2 == address.AddressLine_2
                        && AddressFromDb.StreetName == address.StreetName
                        && AddressFromDb.City == address.City
                        && AddressFromDb.CountryId == address.CountryId
                        && AddressFromDb.CountryName == address.CountryName
                        && AddressFromDb.CountryNameCode == address.CountryNameCode
                        && AddressFromDb.Government == address.Government
                        && AddressFromDb.PostalCode == address.PostalCode) 
                            return StatusCode(200, new { status = "SameObject" });

                        AddressFromDb.BuildingNo = address.BuildingNo;
                        AddressFromDb.FlatNo = address.FlatNo;
                        AddressFromDb.AddressLine_1 = address.AddressLine_1;
                        AddressFromDb.AddressLine_2 = address.AddressLine_2;
                        AddressFromDb.PostalCode = address.PostalCode;
                        AddressFromDb.StreetName = address.StreetName;
                        AddressFromDb.City = address.City;
                        AddressFromDb.CountryNameCode = address.CountryNameCode;
                        AddressFromDb.CountryName = address.CountryName;
                        AddressFromDb.CountryId = address.CountryId;
                        AddressFromDb.Government = address.Government;

                        int result = await UserUnitOfWork.SaveAsync();
                        if (result > 0)
                            return Ok(Constants.Data_SAVED_SUCCESS_Response());

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

        //HelperMedthod
        private bool CheckManuallyChanged_Subdomain(string subdomain)
        {
            return subdomain == HttpContext.Request.Host.Host.Split('.')[0];
        }
    }
}
