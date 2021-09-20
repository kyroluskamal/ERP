import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Constants } from '../../Helpers/constants';
import { OwnerMainComponent } from '../Components/owner-main/owner-main.component';
import { EmailConfirmationOwnerComponent } from '../Components/email-confirmation-owner/email-confirmation-owner.component';
import { CommoneResetPasswordComponent } from '../../CommonComponents/commone-reset-password/commone-reset-password.component';
import { OwnersDashBoardComponent } from '../Dashboard/Owners/Components/owners-dash-board/owners-dash-board.component';
import { NotFoundComponent } from '../../CommonComponents/not-found/not-found.component';
import { OwnerBodyComponent } from '../Components/owner-body/owner-body.component';


const routes: Routes = [
  {
    path: "owners", component: OwnerMainComponent, children:
      [
        { path: "dashboard", component: OwnersDashBoardComponent },
        { path: "", component: OwnerBodyComponent },
        { path: "**", component: NotFoundComponent, pathMatch: 'full' }
      ]
  },
  { path: Constants.Owner_EmailConfirmationUrl, component: EmailConfirmationOwnerComponent },
  { path: Constants.Owner_PasswordResetURL, component: CommoneResetPasswordComponent },
  
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OwnersRoutingModule { }
