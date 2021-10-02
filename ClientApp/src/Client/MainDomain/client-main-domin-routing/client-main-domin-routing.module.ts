import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NotFoundComponent } from '../../../CommonComponents/not-found/not-found.component';
import { CommoneResetPasswordComponent } from '../../../CommonComponents/commone-reset-password/commone-reset-password.component';
import { EmailConfirmationClientComponent } from '../Components/email-confirmation-client/email-confirmation-client.component';
import { RouterModule, Routes } from '@angular/router';
import { ClientMainComponent } from '../../Components/client-main/client-main.component';
import { ClientMainDomainAccountComponent } from '../Components/client-main-domain-account/client-main-domain-account.component';
import { ClientMainDomainBodyComponent } from '../Components/client-main-domain-body/client-main-domain-body.component';
import { RouterConstants } from '../../../Helpers/RouterConstants';
import { ClientAdminGuard } from '../Guards/client-admin.guard';
import { IsLoggedInGuard } from '../Guards/is-logged-in.guard';



const routes: Routes = [
  {
    path: "", component: ClientMainComponent, children:
      [
        {
          path: RouterConstants.Client_MainDomainAccountURL, component: ClientMainDomainAccountComponent, canActivate: [IsLoggedInGuard, ClientAdminGuard]
        },
        { path: "", component: ClientMainDomainBodyComponent },
        { path: RouterConstants.Client_EmailConfirmationUrl, component: EmailConfirmationClientComponent },
        { path: RouterConstants.Client_PasswordResetURL, component: CommoneResetPasswordComponent },
        { path: "**", component: NotFoundComponent, pathMatch: 'prefix' },
      ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ClientMainDominRoutingModule {
}
