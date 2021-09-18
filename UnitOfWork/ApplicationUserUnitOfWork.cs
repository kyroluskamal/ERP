using ERP.Areas.Tenants.Data;
using ERP.Data;
using ERP.Data.Identity;
using ERP.UnitOfWork.Repository.ApplicationUser;
using ERP.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.UnitOfWork
{
    public class ApplicationUserUnitOfWork : IUnitOfWork_ApplicationUser
    {
        public ApplicationDbContext ApplicationDbContext { get; }
        public ApplicationUserRoleManager RoleManager { get; set; }
        public Constants Constants;
        public ApplicationUserUnitOfWork(ApplicationDbContext applicationDbContext,
            ApplicationUserRoleManager roleManager, Constants constants)
        {
            ApplicationDbContext = applicationDbContext;
            RoleManager = roleManager;
            Constants = constants;
        }


        public async void Dispose()
        {
            await ApplicationDbContext.DisposeAsync();
        }

        public async void Save()
        {
            await ApplicationDbContext.SaveChangesAsync();
        }

        public void SetConnectionString(string ConnectionString)
        {
            ApplicationDbContext.Database.SetConnectionString(ConnectionString);
            ApplicationDbContext.Database.Migrate();

            if (!RoleManager.RoleExistsAsync(Constants.Admin_Role).GetAwaiter().GetResult()) 
                RoleManager.CreateAsync(new ApplicationUserRole(Constants.Admin_Role)).GetAwaiter().GetResult();
            if (!RoleManager.RoleExistsAsync(Constants.Moderator_Role).GetAwaiter().GetResult()) 
                RoleManager.CreateAsync(new ApplicationUserRole(Constants.Moderator_Role)).GetAwaiter().GetResult();
            if (!RoleManager.RoleExistsAsync(Constants.Employee_Role).GetAwaiter().GetResult()) 
                RoleManager.CreateAsync(new ApplicationUserRole(Constants.Employee_Role)).GetAwaiter().GetResult();
            if (!RoleManager.RoleExistsAsync(Constants.CustomerService_Role).GetAwaiter().GetResult()) 
                RoleManager.CreateAsync(new ApplicationUserRole(Constants.CustomerService_Role)).GetAwaiter().GetResult();
            if (!RoleManager.RoleExistsAsync(Constants.Client_Role).GetAwaiter().GetResult()) 
                RoleManager.CreateAsync(new ApplicationUserRole(Constants.Client_Role)).GetAwaiter().GetResult();
        }
    }
}
