using ERP.Areas.Owners.Data;
using ERP.Areas.Owners.Interfaces;
using ERP.Areas.Owners.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ERP.Areas.Owners.Controllers
{
    [Area("Owners")]
    [Route("api/[Area]/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public UserManager<Owner> OwnerManager { get; set; }
        public ITokenService TokenService { get; }
        public OwnersDbContext OwnersDbContext { get; set; }
        public AccountController(OwnersDbContext OwnersDbContext, 
            UserManager<Owner> OwnerManager, ITokenService TokenService)
        {
            this.OwnersDbContext = OwnersDbContext;
            this.OwnerManager = OwnerManager;
            this.TokenService = TokenService;
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
        public async Task<OwnerWithToken> Post([FromBody] OwnerRegister Register)
        {
            if (ModelState.IsValid)
            {
                var Owner = new Owner() { Email = Register.Email, UserName = Register.UserName };
                var result = await OwnerManager.CreateAsync(Owner, Register.Password);
                if (result.Succeeded)
                {
                    return new OwnerWithToken {
                        Owner = Owner,
                        Token = TokenService.CreateToken(Owner)
                    };
                }
                return null;
            }
            return null;
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
