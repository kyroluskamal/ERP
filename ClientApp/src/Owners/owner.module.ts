import { NgModule } from '@angular/core';
import { OwnersLoginComponent } from '../Owners/Components/owners-login/owners-login.component';
import { OwnerRegisterComponent } from '../Owners/Components/owner-register/owner-register.component';
import { SharedModule } from '../SharedModules/shared/shared.module';
import { MaterialModule } from '../SharedModules/material/material.module';
import { OwnerNavBarComponent } from './Components/owner-nav-bar/owner-nav-bar.component';
import { OwnerMainComponent } from '../Owners/Components/owner-main/owner-main.component';
import { AppRoutingModule } from '../app/app-routing.module';
import { OwnerBodyComponent } from './Components/owner-body/owner-body.component';
import { NotFoundComponent } from '../CommonComponents/not-found/not-found.component';
import { EmailConfirmationOwnerComponent } from './Components/email-confirmation-owner/email-confirmation-owner.component';

const Commponents = [
  OwnersLoginComponent, OwnerRegisterComponent, OwnerNavBarComponent,
  OwnerMainComponent, OwnerBodyComponent, EmailConfirmationOwnerComponent
]
@NgModule({
  declarations: [Commponents],
  imports: [
    SharedModule, MaterialModule, AppRoutingModule
  ],
  exports: [Commponents]
})
export class OwnerModule { }
