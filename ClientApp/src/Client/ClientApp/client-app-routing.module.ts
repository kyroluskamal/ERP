import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RouterConstants } from 'src/Helpers/RouterConstants';
import { IsNullTenantGuard } from '../MainDomain/Guards/is-null-tenant.guard';
import { ClientAppDashboardComponent } from './Components/Dashboard/client-app-dashboard/client-app-dashboard.component';
import { InventoriesComponent } from './Components/Dashboard/Inventories/inventories/inventories.component';
import { AddNewItemComponent } from './Components/Dashboard/Items/add-new-item/add-new-item.component';
import { ItemBrandsComponent } from './Components/Dashboard/Items/item-brands/item-brands.component';
import { ItemMainCategoriesComponent } from './Components/Dashboard/Items/item-main-categories/item-main-categories.component';
import { ItemUnitsComponent } from './Components/Dashboard/Items/item-units/item-units.component';
import { ItemsComponentComponent } from './Components/Dashboard/Items/items-component/items-component.component';
import { SuppliersComponent } from './Components/Dashboard/Suppliers/suppliers/suppliers.component';
import { LoginOnAppComponent } from './Components/login-on-app/login-on-app.component';



const routes: Routes = [
  {
    path: RouterConstants.App_main, component: ClientAppDashboardComponent, data: { breadcrumb: 'Home' }, children:
      [
        {
          path: RouterConstants.App_Items, children: [
            { path: '', component: ItemsComponentComponent, data: { breadcrumb: 'Products' } },
            { path: RouterConstants.App_ItemMainCategories, component: ItemMainCategoriesComponent, data: { breadcrumb: 'Categories' } },
            { path: RouterConstants.App_ItemUnits, component: ItemUnitsComponent, data: { breadcrumb: 'Units' } },
            { path: RouterConstants.App_ItemBrands, component: ItemBrandsComponent, data: { breadcrumb: 'Brands' } },
            { path: RouterConstants.App_AddNewItem, component: AddNewItemComponent, data: { breadcrumb: 'New' } }
          ],
          //canActivate: [IsNullTenantGuard]
        },
        {
          path: RouterConstants.App_Warehouses, children: [
            { path: "", component: InventoriesComponent, data: { breadcrumb: 'Warehouses' } },
          ]
        },
        {
          path: RouterConstants.App_Suppliers, children: [
            { path: "", component: SuppliersComponent, data: { breadcrumb: 'Suppliers' } },
          ]
        }
      ]
  },
  { path: RouterConstants.App_login, component: LoginOnAppComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ClientAppRoutingModule { }
