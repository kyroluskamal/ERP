import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../SharedModules/shared/shared.module';
import { MaterialModule } from '../SharedModules/material/material.module';
import { AppRoutingModule } from '../app/app-routing.module';
import { ClientMainComponent } from './Components/client-main/client-main.component';
import { ClientAppComponent } from './ClientApp/Components/client-app/client-app.component';
import { ClientRegisterComponent } from './MainDomain/Components/client-register/client-register.component';
import { ClientLoginComponent } from './MainDomain/Components/client-login/client-login.component';
import { ClientMainDomainComponent } from './MainDomain/Components/client-main-domain/client-main-domain.component';
import { ClientMainDomainNavBarComponent } from './MainDomain/Components/client-main-domain-nav-bar/client-main-domain-nav-bar.component';
import { ServerErrorComponent } from '../CommonComponents/server-error/server-error.component';
import { EmailConfirmationClientComponent } from './MainDomain/Components/email-confirmation-client/email-confirmation-client.component';
import { ClientForgetPasswordComponent } from './MainDomain/Components/client-forget-password/client-forget-password.component';
import { ClientResetPasswordComponent } from './MainDomain/Components/client-reset-password/client-reset-password.component';

const Commponents = [
  ClientRegisterComponent, ClientLoginComponent, ClientMainComponent, ClientMainDomainComponent,
  ClientAppComponent, ClientMainDomainNavBarComponent, ServerErrorComponent, EmailConfirmationClientComponent,
  ClientResetPasswordComponent, ClientForgetPasswordComponent
]
@NgModule({
  declarations: [Commponents],
  imports: [
    SharedModule, MaterialModule, AppRoutingModule, CommonModule
  ],
  exports: [Commponents]
})
export class ClientModule { }
