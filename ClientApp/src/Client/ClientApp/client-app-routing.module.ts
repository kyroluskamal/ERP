import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RouterConstants } from 'src/Helpers/RouterConstants';
import { IsNullTenantGuard } from '../MainDomain/Guards/is-null-tenant.guard';
import { ClientAppLoginComponent } from './Components/client-app-login/client-app-login.component';
import { ClientAppRegisterComponent } from './Components/client-app-register/client-app-register.component';
import { ClientAppDashboardComponent } from './Components/Dashboard/client-app-dashboard/client-app-dashboard.component';
import { ItemMainCategoriesComponent } from './Components/Dashboard/Items/item-main-categories/item-main-categories.component';
import { ItemUnitsComponent } from './Components/Dashboard/Items/item-units/item-units.component';
import { ItemsComponentComponent } from './Components/Dashboard/Items/items-component/items-component.component';



const routes: Routes = [
  {
    path: RouterConstants.App_main, component: ClientAppDashboardComponent, children:
      [
        { path: RouterConstants.App_login, component: ClientAppLoginComponent },
        { path: RouterConstants.App_register, component: ClientAppRegisterComponent },
        {
          path: RouterConstants.App_Items, children: [
            { path: '', component: ItemsComponentComponent },
            { path: RouterConstants.App_ItemMainCategories, component: ItemMainCategoriesComponent },
            { path: RouterConstants.App_ItemUnits, component: ItemUnitsComponent }
          ],
          canActivate: [IsNullTenantGuard]
        },
      ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ClientAppRoutingModule { }
