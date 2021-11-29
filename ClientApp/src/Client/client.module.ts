import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../SharedModules/shared/shared.module';
import { MaterialModule } from '../SharedModules/material/material.module';
import { ClientMainComponent } from './Components/client-main/client-main.component';
import { ClientRegisterComponent } from './MainDomain/Components/client-register/client-register.component';
import { ClientLoginComponent } from './MainDomain/Components/client-login/client-login.component';
import { ClientMainDomainComponent } from './MainDomain/Components/client-main-domain/client-main-domain.component';
import { ClientMainDomainNavBarComponent } from './MainDomain/Components/client-main-domain-nav-bar/client-main-domain-nav-bar.component';
import { ServerErrorComponent } from '../CommonComponents/server-error/server-error.component';
import { EmailConfirmationClientComponent } from './MainDomain/Components/email-confirmation-client/email-confirmation-client.component';
import { ClientForgetPasswordComponent } from './MainDomain/Components/client-forget-password/client-forget-password.component';
import { ClientResetPasswordComponent } from './MainDomain/Components/client-reset-password/client-reset-password.component';
import { ClientMainDomainAccountComponent } from './MainDomain/Components/client-main-domain-account/client-main-domain-account.component';
import { ClientMainDominRoutingModule } from './MainDomain/client-main-domin-routing/client-main-domin-routing.module';
import { ClientMainDomainBodyComponent } from './MainDomain/Components/client-main-domain-body/client-main-domain-body.component';
import { CLientAppHomeComponent } from './ClientApp/Components/ClientAppHome/client-app-home/client-app-home.component';
import { ClientAppModule } from './ClientApp/client-app.module';
import { LoginOnAppComponent } from './ClientApp/Components/login-on-app/login-on-app.component';


const Commponents = [
  ClientRegisterComponent, ClientLoginComponent, ClientMainComponent, ClientMainDomainComponent,
  ClientMainDomainNavBarComponent, ServerErrorComponent, EmailConfirmationClientComponent,
  ClientResetPasswordComponent, ClientForgetPasswordComponent, ClientMainDomainAccountComponent,
  ClientMainDomainBodyComponent, LoginOnAppComponent
]
@NgModule({
  declarations: [Commponents],
  imports: [
    SharedModule, MaterialModule, ClientMainDominRoutingModule, CommonModule, ClientAppModule
  ],
  exports: [Commponents]
})
export class ClientModule { }
