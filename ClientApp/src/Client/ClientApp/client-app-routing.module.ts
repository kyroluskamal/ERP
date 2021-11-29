import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RouterConstants } from 'src/Helpers/RouterConstants';
import { IsNullTenantGuard } from '../MainDomain/Guards/is-null-tenant.guard';
import { ClientAppDashboardComponent } from './Components/Dashboard/client-app-dashboard/client-app-dashboard.component';
import { ItemBrandsComponent } from './Components/Dashboard/Items/item-brands/item-brands.component';
import { ItemMainCategoriesComponent } from './Components/Dashboard/Items/item-main-categories/item-main-categories.component';
import { ItemUnitsComponent } from './Components/Dashboard/Items/item-units/item-units.component';
import { ItemsComponentComponent } from './Components/Dashboard/Items/items-component/items-component.component';
import { LoginOnAppComponent } from './Components/login-on-app/login-on-app.component';



const routes: Routes = [
  {
    path: RouterConstants.App_main, component: ClientAppDashboardComponent, children:
      [
        {
          path: RouterConstants.App_Items, children: [
            { path: '', component: ItemsComponentComponent },
            { path: RouterConstants.App_ItemMainCategories, component: ItemMainCategoriesComponent },
            { path: RouterConstants.App_ItemUnits, component: ItemUnitsComponent },
            { path: RouterConstants.App_ItemBrands, component: ItemBrandsComponent }
          ],
          //canActivate: [IsNullTenantGuard]
        },
      ]
  },
  { path: RouterConstants.App_login, component: LoginOnAppComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ClientAppRoutingModule { }
