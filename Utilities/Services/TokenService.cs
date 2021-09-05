using ERP.Areas.Owners.Models;
using ERP.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ERP.Utilities.Services
{
    public class TokenService : ITokenService
    {
        public SymmetricSecurityKey Key { get; set; }
        public TokenService(IConfiguration config)
        {
            Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
        }

        public string CreateOwnerToken(Owner owner)
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

        public string CreateClientToken(ApplicationUser applicationUser)
        {
            var claims = new List<Claim>{
                new Claim(JwtRegisteredClaimNames.NameId, applicationUser.UserName)
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
