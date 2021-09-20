import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NotFoundComponent } from '../../../CommonComponents/not-found/not-found.component';
import { Constants } from '../../../Helpers/constants';
import { CommoneResetPasswordComponent } from '../../../CommonComponents/commone-reset-password/commone-reset-password.component';
import { EmailConfirmationClientComponent } from '../Components/email-confirmation-client/email-confirmation-client.component';
import { RouterModule, Routes } from '@angular/router';
import { ClientMainComponent } from '../../Components/client-main/client-main.component';
import { ClientMainDomainAccountComponent } from '../Components/client-main-domain-account/client-main-domain-account.component';
import { ClientMainDomainBodyComponent } from '../Components/client-main-domain-body/client-main-domain-body.component';



const routes: Routes = [
  {
    path: "", component: ClientMainComponent, children:
      [
        { path: "account", component: ClientMainDomainAccountComponent },
        { path: "", component: ClientMainDomainBodyComponent },
        { path: "**", component: NotFoundComponent, pathMatch: 'prefix' }
      ]
  },
  { path: Constants.Client_EmailConfirmationUrl, component: EmailConfirmationClientComponent },
  { path: Constants.Client_PasswordResetURL, component: CommoneResetPasswordComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ClientMainDominRoutingModule { }
