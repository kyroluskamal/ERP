import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClientMainComponent } from '../Client/Components/client-main/client-main.component';
import { EmailConfirmationClientComponent } from '../Client/MainDomain/Components/email-confirmation-client/email-confirmation-client.component';
import { CommoneResetPasswordComponent } from '../CommonComponents/commone-reset-password/commone-reset-password.component';
import { NotFoundComponent } from '../CommonComponents/not-found/not-found.component';
import { ServerErrorComponent } from '../CommonComponents/server-error/server-error.component';
import { Constants } from '../Helpers/constants';
import { EmailConfirmationOwnerComponent } from '../Owners/Components/email-confirmation-owner/email-confirmation-owner.component';
import { OwnerMainComponent } from '../Owners/Components/owner-main/owner-main.component';

const routes: Routes = [
  { path: "owners", component: OwnerMainComponent },
  { path: "not-found", component: NotFoundComponent },
  { path: "server-error", component: ServerErrorComponent },
  { path: Constants.Client_EmailConfirmationUrl, component: EmailConfirmationClientComponent },
  { path: Constants.Owner_EmailConfirmationUrl, component: EmailConfirmationOwnerComponent },
  { path: Constants.Owner_PasswordResetURL, component: CommoneResetPasswordComponent },
  { path: Constants.Client_PasswordResetURL, component: CommoneResetPasswordComponent },
  { path: "", component: ClientMainComponent },
  { path: "**", component: NotFoundComponent, pathMatch: 'prefix' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
