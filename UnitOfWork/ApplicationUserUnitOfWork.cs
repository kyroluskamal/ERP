﻿using ERP.Data;
using ERP.Data.Identity;
using ERP.Models.Generals;
using ERP.Models.Inventory;
using ERP.Models.Items;
using ERP.UnitOfWork.IRepository.ApplicationUser.Inventory;
using ERP.UnitOfWork.IRepository.ApplicationUser.Items;
using ERP.UnitOfWork.IRepository.ApplicationUser.SuppliersRepo;
using ERP.UnitOfWork.Repository.ApplicationUser.Inventory;
using ERP.UnitOfWork.Repository.ApplicationUser.Items;
using ERP.UnitOfWork.Repository.ApplicationUser.SupliersRepoAsync;
using ERP.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.UnitOfWork
{
    public class ApplicationUserUnitOfWork : IUnitOfWork_ApplicationUser
    {
        public ApplicationDbContext ApplicationDbContext { get; }
        public ApplicationUserRoleManager RoleManager { get; set; }
        public IItemsMainCatRepoAsync ItemMainCategory { get; private set; }
        public IItemsSubCatRepoAsync Item_SubCats { get; private set; }
        public IItemUnitsAsync ItemUnits { get; private set; }
        public IBrandsAsync ItemBrands { get; private set; }
        public IInventoriesRepoAsync Inventories { get; private set; }
        public ISuppliersRepoAsync Suppliers { get; private set; }
        public IInventoryAddressRepoAsync InventoryAddress { get; private set; }
        public IItemsRepoAsync Items { get; private set; }

        public IItemSKUKeysRepoAsync ItemSKUKeys { get; private set; }

        public Constants Constants;
        public ApplicationUserUnitOfWork(ApplicationDbContext applicationDbContext,
            ApplicationUserRoleManager roleManager, Constants constants)
        {
            ApplicationDbContext = applicationDbContext;
            RoleManager = roleManager;
            Constants = constants;
            ItemMainCategory = new ItemsMainCatRepoAsync(applicationDbContext);
            Item_SubCats = new ItemsSubCatRepoAsync(applicationDbContext);
            ItemUnits = new ItemUnitsAsync(applicationDbContext);
            ItemBrands = new BrandsRepoAsync(applicationDbContext);
            Inventories = new InventoriesRepoAsync(applicationDbContext);
            Suppliers = new SuppliersRepoAsync(applicationDbContext);
            InventoryAddress = new InventoryAddressRepoAsync(applicationDbContext);
            Items = new ItemRepoASync(applicationDbContext);
            ItemSKUKeys = new ItemSKUKeysRepoAsync(applicationDbContext);
        }


        public async void Dispose()
        {
            await ApplicationDbContext.DisposeAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await ApplicationDbContext.SaveChangesAsync();
        }

        public int Save()
        {
            return ApplicationDbContext.SaveChanges();
        }
        public async Task SetConnectionStringAsync(string ConnectionString)
        {
            ApplicationDbContext.Database.SetConnectionString(ConnectionString);
            var getMigrations = await ApplicationDbContext.Database.GetPendingMigrationsAsync();
            if (getMigrations.Any())
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
            //Check if the Item Main Category is empty, then add a defaul uncategorized Main Category
            if (ItemMainCategory.GetAllAsync().GetAwaiter().GetResult().Count == 0)
            {
                await ItemMainCategory.AddAsync(new ItemMainCategory
                {
                    MainCatName = "Uncategorized"
                });
            }
            if (await ApplicationDbContext.Users.ToListAsync() != null)
                if (Inventories.GetAllAsync().GetAwaiter().GetResult().Count == 0)
                {
                    await Inventories.AddAsync(new Inventories
                    {
                        WarehouseName = "Main warehouse",
                        IsActive = true,
                        IsMainInventory = true,
                        AddedBy_UserId = 1,
                        AddedBy_UserName = "Owner"
                    });
                }

            
        }

    }
}
