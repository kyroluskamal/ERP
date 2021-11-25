import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClientMainComponent } from 'src/Client/Components/client-main/client-main.component';
import { ClientMainDomainAccountComponent } from 'src/Client/MainDomain/Components/client-main-domain-account/client-main-domain-account.component';
import { ClientAdminGuard } from 'src/Client/MainDomain/Guards/client-admin.guard';
import { IsLoggedInGuard } from 'src/Client/MainDomain/Guards/is-logged-in.guard';
import { CommoneResetPasswordComponent } from 'src/CommonComponents/commone-reset-password/commone-reset-password.component';
import { EmailConfirmationClientComponent } from '../Client/MainDomain/Components/email-confirmation-client/email-confirmation-client.component';
import { NotFoundComponent } from '../CommonComponents/not-found/not-found.component';
import { ServerErrorComponent } from '../CommonComponents/server-error/server-error.component';
import { RouterConstants } from '../Helpers/RouterConstants';


const routes: Routes = [

  //{ path: RouterConstants.Client_EmailConfirmationUrl, component: EmailConfirmationClientComponent },
  { path: "not-found", component: NotFoundComponent },
  { path: "server-error", component: ServerErrorComponent },
  { path: "**", component: NotFoundComponent, pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, /*{ enableTracing: true }*/)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
