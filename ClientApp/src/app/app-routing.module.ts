import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClientMainComponent } from '../Client/Components/client-main/client-main.component';
import { EmailConfirmationClientComponent } from '../Client/MainDomain/Components/email-confirmation-client/email-confirmation-client.component';
import { ClientAdminGuard } from '../Client/MainDomain/Guards/client-admin.guard';
import { CommoneResetPasswordComponent } from '../CommonComponents/commone-reset-password/commone-reset-password.component';
import { NotFoundComponent } from '../CommonComponents/not-found/not-found.component';
import { ServerErrorComponent } from '../CommonComponents/server-error/server-error.component';
import { Constants } from '../Helpers/constants';
import { EmailConfirmationOwnerComponent } from '../Owners/Components/email-confirmation-owner/email-confirmation-owner.component';
import { OwnerBodyComponent } from '../Owners/Components/owner-body/owner-body.component';
import { OwnerMainComponent } from '../Owners/Components/owner-main/owner-main.component';

const routes: Routes = [
  { path: "not-found", component: NotFoundComponent },
  { path: "server-error", component: ServerErrorComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { enableTracing: true })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
