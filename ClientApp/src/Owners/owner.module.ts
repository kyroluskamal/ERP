import { NgModule } from '@angular/core';
import { OwnersLoginComponent } from '../Owners/Components/owners-login/owners-login.component';
import { OwnerRegisterComponent } from '../Owners/Components/owner-register/owner-register.component';
import { SharedModule } from '../SharedModules/shared/shared.module';
import { MaterialModule } from '../SharedModules/material/material.module';
import { OwnerNavBarComponent } from './Components/owner-nav-bar/owner-nav-bar.component';
import { OwnerMainComponent } from '../Owners/Components/owner-main/owner-main.component';
import { OwnerBodyComponent } from './Components/owner-body/owner-body.component';
import { EmailConfirmationOwnerComponent } from './Components/email-confirmation-owner/email-confirmation-owner.component';
import { OwnerResetPasswordComponent } from './Components/owner-reset-password/owner-reset-password.component';
import { OwnerForgetPasswordComponent } from './Components/owner-forget-password/owner-forget-password.component';
import { OwnersRoutingModule } from './owners-routing/owners-routing.module';
import { OwnersDashBoardComponent } from './Dashboard/Owners/Components/owners-dash-board/owners-dash-board.component';
import { TranslateModule } from '@ngx-translate/core';

const Commponents = [
  OwnersLoginComponent, OwnerRegisterComponent, OwnerNavBarComponent,
  OwnerMainComponent, OwnerBodyComponent, EmailConfirmationOwnerComponent,
  OwnerResetPasswordComponent, OwnerForgetPasswordComponent,
  OwnersDashBoardComponent
]
@NgModule({
  declarations: [Commponents],
  imports: [
    SharedModule, MaterialModule, OwnersRoutingModule
  ],
  exports: [Commponents]
})
export class OwnerModule { }
