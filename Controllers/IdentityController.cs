using ERP.Data;
using ERP.Models;
using ERP.Utilities.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Data.Identity;
using ERP.Areas.Tenants.Models;
using ERP.Areas.Tenants.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Infrastructure;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Data.Entity;
using System.Diagnostics;
using ERP.UnitOfWork;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        public ApplicationUserManager UserManager { get; set; }
        public ITokenService TokenService { get; set; }
        public IUnitOfWork_Tenants TenantsUnitOfWork { get; set; }
        public IUnitOfWork_Owners OwnersUnitOfWork { get; set; }
        public ApplicationUserSignIngManager ApplicationUserSignIngManager { get; }
        public IUnitOfWork_ApplicationUser ClientUnitOfWork { get; set; }
        public DbContextOptions<ApplicationDbContext> DbOptions;

        public IdentityController(
            ApplicationUserManager userManager, ITokenService tokenService,
            IUnitOfWork_Tenants tenantsUnitOfWork, IUnitOfWork_ApplicationUser clientUnitOfWork,
            IUnitOfWork_Owners ownersUnitOfWork, DbContextOptions<ApplicationDbContext> dbOptions,
            ApplicationUserSignIngManager applicationUserSignIngManager)
        {
            UserManager = userManager;
            TokenService = tokenService;
            TenantsUnitOfWork = tenantsUnitOfWork;
            ClientUnitOfWork = clientUnitOfWork;
            OwnersUnitOfWork = ownersUnitOfWork;
            DbOptions = dbOptions;
            ApplicationUserSignIngManager = applicationUserSignIngManager;
        }

        // GET: api/<IdentityController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<IdentityController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<IdentityController>
        [HttpPost]
        public async Task<ActionResult<UserWithToken>> Post([FromBody] ClientRegister clientRegister)
        {
            if (ModelState.IsValid)
            {
                var tenantbyEmail = TenantsUnitOfWork.Tenants.TenantByEmail(clientRegister.Email);
                var tenantbyUsername = TenantsUnitOfWork.Tenants.TenantByUsername(clientRegister.UserName);
                var tenantbySubdomain = TenantsUnitOfWork.Tenants.TenantBySubdomain(clientRegister.Subdomain.ToLower());
                if (tenantbyEmail != null && tenantbySubdomain != null && tenantbyUsername != null)
                    return BadRequest("Do you try to create an account with the same Email, Username and Subdomain?. " +
                        "you can login or reset your password if you have forgetton it");
                else if(tenantbyEmail != null && tenantbySubdomain != null && tenantbyUsername == null)
                    return BadRequest("Email and Subdomain both are already exists");
                else if(tenantbyEmail != null && tenantbySubdomain == null && tenantbyUsername != null)
                    return BadRequest("Email and Username both are already exists");
                else if(tenantbyEmail == null && tenantbySubdomain != null && tenantbyUsername != null)
                    return BadRequest("subdomain and Username both are already exists");
                else if (tenantbyEmail != null && tenantbySubdomain == null && tenantbyUsername == null)
                    return BadRequest("This Email is already taken");
                else if (tenantbyEmail == null && tenantbySubdomain == null && tenantbyUsername != null)
                    return BadRequest("This Username Is already taken");
                else if (tenantbyEmail == null && tenantbySubdomain != null && tenantbyUsername == null)
                    return BadRequest("Subdomain name is already taken.Please,Choose another one");
                var Tenant = new TenantsInfo() {
                    CompanyName = clientRegister.CompanyName,
                    Subdomain = clientRegister.Subdomain.ToLower(),
                    Username = clientRegister.UserName,
                    Email = clientRegister.Email,
                    ConnectionString = $"Server=(localdb)\\mssqllocaldb;Database={clientRegister.Subdomain};Trusted_Connection=True;MultipleActiveResultSets=true"
                };      
                 TenantsUnitOfWork.Tenants.Add(Tenant);
                 TenantsUnitOfWork.Save();
                ClientUnitOfWork.SetConnectionString(Tenant.ConnectionString);

                var User = new ApplicationUser() { Email = clientRegister.Email, UserName = clientRegister.UserName };
                var result = await UserManager.CreateAsync(User, clientRegister.Password);
                if (result.Succeeded)return new UserWithToken{ Username = User.UserName, Token = TokenService.CreateClientToken(User)};
                else return BadRequest(result.Errors);
            }
            return BadRequest(ModelState);
        }
        // POST api/<IdentityController>/LoginMainDomain
        [HttpPost("LoginMainDomain")]
        public async Task<ActionResult<UserWithToken>> LoginMainDomain([FromBody] ClientLogin clientLogin)
        {
            if (ModelState.IsValid) { 
                //Get ConnectionString From Tenant Db
                var tenant = TenantsUnitOfWork.Tenants.TenantByEmail(clientLogin.Email);
                if (tenant == null) return BadRequest("There is no account by this mail");
                //Connect to the correct Db based on the Connectionstring
                ClientUnitOfWork.SetConnectionString(tenant.ConnectionString);
                //Get user From Users table
                var user = UserManager.Users.SingleOrDefault(x => x.Email == clientLogin.Email);
                if (user == null) return Unauthorized("We can't find a user with this email. Check your email and try again");
                //Sign In User
                var result = await ApplicationUserSignIngManager.CheckPasswordSignInAsync(user, clientLogin.Password, false);
                if (result.Succeeded)
                    return new UserWithToken{Username = user.UserName, Token = TokenService.CreateClientToken(user)};
                else return Unauthorized("Wrong Password");
            }
            return BadRequest(ModelState);
        }

        // PUT api/<IdentityController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<IdentityController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
