using ERP.Areas.Tenants.Models;
using ERP.Data;
using ERP.Data.Identity;
using ERP.Models;
using ERP.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Utilities.Services
{
    public class AuthenticationService
    {
        public ApplicationUserManager UserManager { get; }
        public Constants Constants { get; }
        public IUnitOfWork_Tenants TenantsUnitOfWork { get; }
        public IUnitOfWork_ApplicationUser ClientUnitOfWork { get; }
        public DbContextOptions<ApplicationDbContext> DbOptions { get; }
        public ApplicationUserRoleManager RoleManager { get; }
        public ApplicationUserSignIngManager ApplicationUserSignIngManager { get; }
        public ITokenService TokenService { get; }

        public AuthenticationService(ApplicationUserManager userManager, Constants constants,
            IUnitOfWork_Tenants tenantsUnitOfWork, IUnitOfWork_ApplicationUser clientUnitOfWork,
            DbContextOptions<ApplicationDbContext> dbOptions, ApplicationUserRoleManager roleManager,
            ApplicationUserSignIngManager applicationUserSignIngManager, ITokenService tokenService)
        {
            UserManager = userManager;
            Constants = constants;
            TenantsUnitOfWork = tenantsUnitOfWork;
            ClientUnitOfWork = clientUnitOfWork;
            DbOptions = dbOptions;
            RoleManager = roleManager;
            ApplicationUserSignIngManager = applicationUserSignIngManager;
            TokenService = tokenService;
        }

        public async Task<ApplicationUser> AuthenticateClients(ClientLogin clientLogin, TenantsInfo tenant)
        {
            //Connect to the correct Db based on the Connectionstring
            await ClientUnitOfWork.SetConnectionStringAsync(tenant.ConnectionString);
            ApplicationUser user = await UserManager.FindByEmailAsync(clientLogin.Email);
            if (user == null) return null;
            var result = await ApplicationUserSignIngManager.PasswordSignInAsync(user, clientLogin.Password, false, false);
            if (result.Succeeded)
            {
                user.PasswordHash = null;
                user.Token = TokenService.CreateClientToken(user);
                return user;
            }
            user.WrongPassowrd = true;
            return user;
        }
    }
}
