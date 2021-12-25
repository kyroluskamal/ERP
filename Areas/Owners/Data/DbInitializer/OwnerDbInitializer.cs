using ERP.Areas.Owners.Models;
using ERP.Areas.Owners.Models.Identity;
using ERP.UnitOfWork;
using ERP.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Areas.Owners.Data.DbInitializer
{
    public class OwnerDbInitializer : IOwnerDbInitializer
    {
        private readonly OwnersDbContext OwnerDbContext;
        private readonly OwnerUserManager UserManager;
        private readonly OwnerRoleManager RoleManager;
        private readonly Constants Constants;


        public OwnerDbInitializer(OwnersDbContext ownerDbContext, Constants constants,
            OwnerUserManager userManager, OwnerRoleManager roleManager,
            IUnitOfWork_Owners ownersUnitOfWork)
        {
            OwnerDbContext = ownerDbContext;
            RoleManager = roleManager;
            OwnersUnitOfWork = ownersUnitOfWork;
            UserManager = userManager;
            Constants = constants;
        }

        public IUnitOfWork_Owners OwnersUnitOfWork { get; }

        public async Task Initialize()
        {
            try
            {
                if (OwnerDbContext.Database.GetPendingMigrations().Any())
                {
                    OwnerDbContext.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }

            if (OwnerDbContext.Roles.Any(r => r.Name == Constants.SuperAdmin_Role)) return;

            if (!RoleManager.RoleExistsAsync(Constants.Admin_Role).GetAwaiter().GetResult())
                RoleManager.CreateAsync(new OwnerRole(Constants.Admin_Role)).GetAwaiter().GetResult();
            if (!RoleManager.RoleExistsAsync(Constants.SuperAdmin_Role).GetAwaiter().GetResult())
                RoleManager.CreateAsync(new OwnerRole(Constants.SuperAdmin_Role)).GetAwaiter().GetResult();
            if (!RoleManager.RoleExistsAsync(Constants.Moderator_Role).GetAwaiter().GetResult())
                RoleManager.CreateAsync(new OwnerRole(Constants.Moderator_Role)).GetAwaiter().GetResult();
            if (!RoleManager.RoleExistsAsync(Constants.Employee_Role).GetAwaiter().GetResult())
                RoleManager.CreateAsync(new OwnerRole(Constants.Employee_Role)).GetAwaiter().GetResult();
            if (!RoleManager.RoleExistsAsync(Constants.CustomerService_Role).GetAwaiter().GetResult())
                RoleManager.CreateAsync(new OwnerRole(Constants.CustomerService_Role)).GetAwaiter().GetResult();

            Owner Admin = OwnerDbContext.Users.Where(u => u.Email == "kyroluskamal@gmail.com").FirstOrDefault();
            if (Admin == null)
            {
                UserManager.CreateAsync(new Owner
                {
                    UserName = "KyrolusKamal",
                    Email = "kyroluskamal@gmail.com",
                    EmailConfirmed = true,
                    FirstName = "Kyrolus",
                    LastName = "Faheem"
                }, "Kiko@2009").GetAwaiter().GetResult();

                Owner user = OwnerDbContext.Users.Where(u => u.Email == "kyroluskamal@gmail.com").FirstOrDefault();

                if (!UserManager.IsInRoleAsync(user, Constants.SuperAdmin_Role).GetAwaiter().GetResult())
                    await UserManager.AddToRoleAsync(user, Constants.SuperAdmin_Role);
            }

        }


    }
}
