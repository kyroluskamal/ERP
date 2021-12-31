using ERP.Areas.Tenants.Models;
using ERP.Data;
using ERP.Data.Identity;
using ERP.Models.Supplier;
using ERP.UnitOfWork;
using ERP.Utilities;
using ERP.Utilities.Helpers;
using ERP.Utilities.Services;
using ERP.Utilities.Services.EmailService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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

        #region Suppliers functions
        //Get all Suppliers
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
                    List<Suppliers> suppliers = await UserUnitOfWork.Suppliers.GetAllAsync();
                    foreach (Suppliers supplier in suppliers) supplier.ApplicationUser.PasswordHash = null;
                    return suppliers;
                }
                return BadRequest(Constants.NullTentant_Error_Response());
            }
            return BadRequest(Constants.HackTrying_Error_Response());
        }
        //............................................................Add Supplier
        [HttpPost(nameof(AddSupplier))]
        [Authorize]
        [ValidateAntiForgeryTokenCustom]
        public async Task<IActionResult> AddSupplier([FromBody] Suppliers Supplier)
        {
            if (!ModelState.IsValid)
                return BadRequest(Constants.ModelState_ERROR_Response(ModelState));

            if (CheckManuallyChanged_Subdomain(Supplier.Subdomain))
            {
                var tenant = await TenantsUnitOfWork.Tenants.TenantBySubdomainAsync(Supplier.Subdomain);
                if (tenant != null)
                {
                    await UserUnitOfWork.SetConnectionStringAsync(tenant.ConnectionString);

                    if (!await UserUnitOfWork.Suppliers.IsUnique(x => x.BusinessName == Supplier.BusinessName))
                        return BadRequest(Constants.Unique_Field_ERROR_Response());
                    
                    await UserUnitOfWork.Suppliers.AddAsync(new Suppliers
                    {
                        BusinessName = Supplier.BusinessName,
                        FirstName = Supplier.FirstName,
                        LastName = Supplier.LastName,
                        Telephone = Supplier.Telephone,
                        MobilePhone = Supplier.MobilePhone,
                        TaxID = Supplier.TaxID,
                        CR = Supplier.CR,
                        Email = Supplier.Email,
                        DateCreated = DateTime.Today,
                        OpeningBalanceDate = Supplier.OpeningBalanceDate,
                        OpeningBalance = Supplier.OpeningBalance,
                        Balance = Supplier.OpeningBalance,
                        Logo = Supplier.Logo,
                        Notes = Supplier.Notes,
                        Currency = Supplier.Currency,
                        CurrencyId = Supplier.CurrencyId,
                        CountryName = Supplier.CountryName,
                        CountryNameCode = Supplier.CountryNameCode,
                        CountryId = Supplier.CountryId,
                        AddedBy_UserId = Supplier.AddedBy_UserId,
                        AddedBy_UserName = Supplier.AddedBy_UserName
                    });
                    int result = await UserUnitOfWork.SaveAsync();
                    if (result > 0)
                    {
                        var suppliers = await UserUnitOfWork.Suppliers.GetAllAsync(x => x.BusinessName == Supplier.BusinessName);
                        var lastSupplier = suppliers.Last(x => x.BusinessName == Supplier.BusinessName);
                        lastSupplier.ApplicationUser.PasswordHash = null;
                        return Ok(lastSupplier);
                    }
                    return BadRequest(Constants.DataAddtion_ERROR_Response());
                }
                return BadRequest(Constants.NullTentant_Error_Response());
            }
            return BadRequest(Constants.HackTrying_Error_Response());
        }

        //...........................................................Update Supplier
        [HttpPut(nameof(UpdateSupplier))]
        [Authorize]
        [ValidateAntiForgeryTokenCustom]
        public async Task<IActionResult> UpdateSupplier(Suppliers Supplier)
        {
            if (!ModelState.IsValid)
                return BadRequest(Constants.ModelState_ERROR_Response(ModelState));

            if (CheckManuallyChanged_Subdomain(Supplier.Subdomain))
            {
                //get tenant from TenantDP
                var Tenant = await TenantsUnitOfWork.Tenants.TenantBySubdomainAsync(Supplier.Subdomain);
                if (Tenant != null)
                {
                    //if Tentnat is found, set the connection stirng
                    await UserUnitOfWork.SetConnectionStringAsync(Tenant.ConnectionString);
                    // Check if it is unique
                    if (!await UserUnitOfWork.Suppliers.IsUnique(x => x.BusinessName == Supplier.BusinessName
                            && x.Id != Supplier.Id))
                        return BadRequest(Constants.Unique_Field_ERROR_Response());
                    //Check if the unit is found in DB
                    Suppliers SupplierFromDb = await UserUnitOfWork.Suppliers.GetAsync(Supplier.Id);

                    if (SupplierFromDb != null)
                    {
                        if (SupplierFromDb.BusinessName == Supplier.BusinessName
                        && SupplierFromDb.FirstName == Supplier.FirstName
                        && SupplierFromDb.LastName == Supplier.LastName
                        && SupplierFromDb.Telephone == Supplier.Telephone
                        && SupplierFromDb.MobilePhone == Supplier.MobilePhone
                        && SupplierFromDb.TaxID == Supplier.TaxID
                        && SupplierFromDb.CR == Supplier.CR
                        && SupplierFromDb.Email == Supplier.Email
                        && SupplierFromDb.OpeningBalance == Supplier.OpeningBalance
                        && SupplierFromDb.OpeningBalanceDate == Supplier.OpeningBalanceDate
                        && SupplierFromDb.Logo == Supplier.Logo
                        && SupplierFromDb.Notes == Supplier.Notes
                        && SupplierFromDb.Currency == Supplier.Currency
                        && SupplierFromDb.CurrencyId == Supplier.CurrencyId
                        && SupplierFromDb.CountryName == Supplier.CountryName
                        && SupplierFromDb.CountryNameCode == Supplier.CountryNameCode
                        && SupplierFromDb.CountryId == Supplier.CountryId
                       ) return StatusCode(200, new { status = "SameObject" });

                        SupplierFromDb.BusinessName = Supplier.BusinessName;
                        SupplierFromDb.FirstName = Supplier.FirstName;
                        SupplierFromDb.LastName = Supplier.LastName;
                        SupplierFromDb.Telephone = Supplier.Telephone;
                        SupplierFromDb.MobilePhone = Supplier.MobilePhone;
                        SupplierFromDb.TaxID = Supplier.TaxID;
                        SupplierFromDb.CR = Supplier.CR;
                        SupplierFromDb.Email = Supplier.Email;
                        SupplierFromDb.OpeningBalanceDate = Supplier.OpeningBalanceDate;
                        SupplierFromDb.Logo = Supplier.Logo;
                        SupplierFromDb.Notes = Supplier.Notes;
                        SupplierFromDb.Currency = Supplier.Currency;
                        SupplierFromDb.CurrencyId = Supplier.CurrencyId;
                        SupplierFromDb.CountryName = Supplier.CountryName;
                        SupplierFromDb.CountryNameCode = Supplier.CountryNameCode;
                        SupplierFromDb.CountryId = Supplier.CountryId;

                        SupplierFromDb.Balance = (SupplierFromDb.Balance - SupplierFromDb.OpeningBalance) + Supplier.OpeningBalance;
                        SupplierFromDb.OpeningBalance = Supplier.OpeningBalance;

                        Debug.WriteLine(SupplierFromDb.Balance - SupplierFromDb.OpeningBalance);
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

        //...........................................................DELETE Supplier
        [HttpDelete(nameof(DeleteSupplier))]
        [Authorize]
        [ValidateAntiForgeryTokenCustom]
        public async Task<IActionResult> DeleteSupplier(string Subdomain, int Id)
        {
            if (CheckManuallyChanged_Subdomain(Subdomain))
            {
                TenantsInfo Tenant = await TenantsUnitOfWork.Tenants.TenantBySubdomainAsync(Subdomain);
                if (Tenant != null)
                {
                    await UserUnitOfWork.SetConnectionStringAsync(Tenant.ConnectionString);
                    Suppliers supplierToDelete = await UserUnitOfWork.Suppliers.GetAsync(Id);
                    if (supplierToDelete != null)
                    {
                        await UserUnitOfWork.Suppliers.RemoveAsync(supplierToDelete.Id);
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

        #endregion

        //HelperMedthod
        private byte[] GetByteArrayFromImage(IFormFile file)
        {
            using (var target = new MemoryStream())
            {
                file.CopyTo(target);
                return target.ToArray();
            }
        }
        public byte[] ConvertToBytes(IFormFile image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.OpenReadStream());
            imageBytes = reader.ReadBytes((int)image.Length);
            return imageBytes;
        }
        private bool CheckManuallyChanged_Subdomain(string subdomain)
        {
            return subdomain == HttpContext.Request.Host.Host.Split('.')[0];
        }
    }
}
