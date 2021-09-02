using ERP.Areas.Owners.Interfaces;
using ERP.Areas.Owners.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Areas.Owners.Services
{
    public class TokenService : ITokenService
    {
        public SymmetricSecurityKey Key { get; set; }
        public TokenService(IConfiguration config)
        {
            Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
        }

        public string CreateToken(Owner owner)
        {
            var claims = new List<Claim>{
                new Claim(JwtRegisteredClaimNames.NameId, owner.UserName)
            };
            var cred = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescribtor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = cred
            };

            var TokenHandler = new JwtSecurityTokenHandler();
            var token = TokenHandler.CreateToken(tokenDescribtor);
            return TokenHandler.WriteToken(token);
        }
    }
}
