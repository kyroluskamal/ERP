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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly ApplicationDbContext userDbContext;
        public UserManager<ApplicationUser> UserManager { get; }
        public ITokenService TokenService { get; }
        public TenantsDbContext tenantsDbContext { get; }
        public DbContextOptions<ApplicationDbContext> DbOptions;

        public IdentityController(ApplicationDbContext UserDbContext,
            UserManager<ApplicationUser> UserManager, ITokenService TokenService,
            TenantsDbContext tenantsDbContext, DbContextOptions<ApplicationDbContext> DbOptions)
        {
            userDbContext = UserDbContext;
            this.UserManager = UserManager;
            this.TokenService = TokenService;
            this.tenantsDbContext = tenantsDbContext;
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
        public async Task<UserWithToken> Post([FromBody] ClientRegister clientRegister)
        {
            if (ModelState.IsValid)
            {
                var Tenant = new TenantsInfo() {
                    CompanyName = clientRegister.CompanyName,
                    Subdomain = clientRegister.Subdomain,
                    ConnectionString = $"Server=(localdb)\\mssqllocaldb;Database={clientRegister.Subdomain};Trusted_Connection=True;MultipleActiveResultSets=true"
                };
                tenantsDbContext.Add(Tenant);
                tenantsDbContext.SaveChanges();

                userDbContext.Database.SetConnectionString(Tenant.ConnectionString);
                userDbContext.Database.Migrate();
                

                var User = new ApplicationUser() { Email = clientRegister.Email, UserName = clientRegister.UserName };
                var result = await UserManager.CreateAsync(User, clientRegister.Password);
                if (result.Succeeded)
                {
                    return new UserWithToken
                    {
                        Username = User.UserName,
                        Token = TokenService.CreateClientToken(User)
                    };
                }
                return null;
            }
            return null;
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
