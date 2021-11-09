import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RouterConstants } from 'src/Helpers/RouterConstants';
import { EmailConfirmationClientComponent } from '../MainDomain/Components/email-confirmation-client/email-confirmation-client.component';
import { ClientAppLoginComponent } from './Components/client-app-login/client-app-login.component';
import { ClientAppRegisterComponent } from './Components/client-app-register/client-app-register.component';
import { ClientAppDashboardComponent } from './Components/Dashboard/client-app-dashboard/client-app-dashboard.component';
import { ClientDashboardHomeComponent } from './Components/Dashboard/client-dashboard-home/client-dashboard-home.component';
import { ItemsComponentComponent } from './Components/Dashboard/items-component/items-component.component';



const routes: Routes = [
  {
    path: RouterConstants.App_main, component: ClientAppDashboardComponent, children:
      [
        { path: RouterConstants.App_login, component: ClientAppLoginComponent },
        { path: RouterConstants.App_register, component: ClientAppRegisterComponent },
        { path: RouterConstants.App_Items, component: ItemsComponentComponent },

      ]
  }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ClientAppRoutingModule { }
