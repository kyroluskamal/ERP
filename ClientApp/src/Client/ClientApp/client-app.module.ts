import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from 'src/SharedModules/shared/shared.module';
import { MaterialModule } from 'src/SharedModules/material/material.module';
import { ClientAppDashboardComponent } from './Components/Dashboard/client-app-dashboard/client-app-dashboard.component';
import { ClientAppRoutingModule } from './client-app-routing.module';
import { ClientAppHomeNavbarComponent } from './Components/ClientAppHome/client-app-home-navbar/client-app-home-navbar.component';
import { ClientAppLoginComponent } from './Components/client-app-login/client-app-login.component';
import { ClientAppRegisterComponent } from './Components/client-app-register/client-app-register.component';
import { AppRoutingModule } from 'src/app/app-routing.module';
import { CLientAppHomeComponent } from './Components/ClientAppHome/client-app-home/client-app-home.component';
import { ClientDashboardHomeComponent } from './Components/Dashboard/client-dashboard-home/client-dashboard-home.component';



const Commponents = [
  ClientAppDashboardComponent, ClientAppHomeNavbarComponent, CLientAppHomeComponent,
  ClientAppLoginComponent, ClientAppRegisterComponent
]
@NgModule({
  declarations: [Commponents, ClientDashboardHomeComponent],
  imports: [
    SharedModule, MaterialModule, ClientAppRoutingModule, CommonModule, AppRoutingModule
  ],
  exports: [Commponents]
})
export class ClientAppModule { }
