using ERP.Areas.Owners.Data;
using ERP.Areas.Owners.Models;
using ERP.Areas.Owners.Models.Identity;
using ERP.UnitOfWork;
using ERP.Utilities.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ERP.Areas.Owners.Controllers
{
    [Area("Owners")]
    [Route("api/[Area]/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public OwnerUserManager OwnerManager { get; set; }
        public ITokenService TokenService { get; }
        public IUnitOfWork_Owners OwnersUnitOfWork { get; }
        public DbContextOptions<OwnersDbContext> DbOptions { get; }
        public OwnerSignInManager OwnerSigninManager { get; }

        public AccountController(OwnerUserManager ownerManager, ITokenService tokenService,
            IUnitOfWork_Owners ownersUnitOfWork, DbContextOptions<OwnersDbContext> dbOptions,
            OwnerSignInManager ownerSigninManager)
        {
            OwnerManager = ownerManager;
            TokenService = tokenService;
            OwnersUnitOfWork = ownersUnitOfWork;
            DbOptions = dbOptions;
            OwnerSigninManager = ownerSigninManager;
        }

        // GET: api/<AccountController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AccountController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AccountController>
        [HttpPost]
        public async Task<ActionResult<OwnerWithToken>> Post([FromBody] OwnerRegister Register)
        {
            if (ModelState.IsValid)
            {
                var Owner = new Owner() { Email = Register.Email, UserName = Register.UserName };
                var result = await OwnerManager.CreateAsync(Owner, Register.Password);
                if (result.Succeeded)
                {
                    return new OwnerWithToken
                    {
                        Username = Owner.UserName,
                        Token = TokenService.CreateOwnerToken(Owner)
                    };
                }
                return BadRequest(result.Errors);
            }
            return null;
        }

        // POST api/<AccountController>/OwnerLogin
        [HttpPost("OwnerLogin")]
        public async Task<ActionResult<OwnerWithToken>> OwnerLogin([FromBody] OwnerLogin ownerLogin)
        {
            if (ModelState.IsValid)
            {
                //Get user From Users table
                var user = OwnerManager.Users.SingleOrDefault(x => x.Email == ownerLogin.Email);
                if (user == null) return Unauthorized("There is no account by this mail");
                //Sign In User
                var result = await OwnerSigninManager.CheckPasswordSignInAsync(user, ownerLogin.Password, false);

                if (result.Succeeded) return new OwnerWithToken { Username = user.UserName, Token = TokenService.CreateOwnerToken(user) };
                else return Unauthorized("Wrong Password");
            }
            return BadRequest(ModelState);
        }
        // PUT api/<AccountController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
