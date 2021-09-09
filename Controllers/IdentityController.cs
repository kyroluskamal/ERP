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
        private readonly ApplicationDbContext userDbContext;
        public ApplicationUserManager UserManager { get; set; }
        public ITokenService TokenService { get; set; }
        public IUnitOfWork_Tenants TenantsUnitOfWork { get; set; }
        public IUnitOfWork_Owners OwnersUnitOfWork { get; set; }
        public IUnitOfWork_ApplicationUser ClientUnitOfWork { get; set; }
        public DbContextOptions<ApplicationDbContext> DbOptions;

        public IdentityController(ApplicationDbContext UserDbContext,
            ApplicationUserManager UserManager, ITokenService TokenService,
            IUnitOfWork_Tenants tenantsUnitOfWork, IUnitOfWork_ApplicationUser clientUnitOfWork,
            IUnitOfWork_Owners ownersUnitOfWork, DbContextOptions<ApplicationDbContext> DbOptions)
        {
            userDbContext = UserDbContext;
            this.UserManager = UserManager;
            this.TokenService = TokenService;
            TenantsUnitOfWork = tenantsUnitOfWork;
            ClientUnitOfWork = clientUnitOfWork;
            OwnersUnitOfWork = ownersUnitOfWork;
            this.DbOptions = DbOptions;
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
                if (TenantsUnitOfWork.Tenants.IsSubdomainExist(clientRegister.Subdomain.ToLower()))
                    return BadRequest("Subdomain name is already taken.Please,Choose another one");
                var Tenant = new TenantsInfo() {
                    CompanyName = clientRegister.CompanyName,
                    Subdomain = clientRegister.Subdomain.ToLower(),
                    ConnectionString = $"Server=(localdb)\\mssqllocaldb;Database={clientRegister.Subdomain};Trusted_Connection=True;MultipleActiveResultSets=true"
                };
                TenantsUnitOfWork.Tenants.Add(Tenant);
                TenantsUnitOfWork.Save();
                ClientUnitOfWork.SetConnectionString(Tenant.ConnectionString);

                var User = new ApplicationUser() { Email = clientRegister.Email, UserName = clientRegister.UserName };
                var result = await UserManager.CreateAsync(User, clientRegister.Password);
                Debug.WriteLine(result);
                if (result.Succeeded)
                {
                    return new UserWithToken
                    {
                        Username = User.UserName,
                        Token = TokenService.CreateClientToken(User)
                    };
                }
                else
                    return BadRequest(result.Errors);
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
