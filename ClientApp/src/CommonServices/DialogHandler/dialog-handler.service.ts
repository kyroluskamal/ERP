import { Injectable } from '@angular/core';
import { MediaChange, MediaObserver } from '@angular/flex-layout';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { Subscription } from 'rxjs';
import { ClientForgetPasswordComponent } from '../../Client/MainDomain/Components/client-forget-password/client-forget-password.component';
import { ClientLoginComponent } from '../../Client/MainDomain/Components/client-login/client-login.component';
import { ClientRegisterComponent } from '../../Client/MainDomain/Components/client-register/client-register.component';
import { ClientResetPasswordComponent } from '../../Client/MainDomain/Components/client-reset-password/client-reset-password.component';
import { OwnerForgetPasswordComponent } from '../../Owners/Components/owner-forget-password/owner-forget-password.component';
import { OwnerRegisterComponent } from '../../Owners/Components/owner-register/owner-register.component';
import { OwnerResetPasswordComponent } from '../../Owners/Components/owner-reset-password/owner-reset-password.component';
import { OwnersLoginComponent } from '../../Owners/Components/owners-login/owners-login.component';
import { ConstantsService } from '../constants.service';

@Injectable({
  providedIn: 'root'
})
export class DialogHandlerService {

  constructor(public Dialog: MatDialog, private mediaObserver: MediaObserver, public Constants: ConstantsService) {

  }

  OpenOwnerRegisterDialog() {
    let RegisterDialogConfig: MatDialogConfig = new MatDialogConfig();
    RegisterDialogConfig.panelClass = "OwnerRegisterDialog";
    RegisterDialogConfig.autoFocus = true;
    this.Dialog.open(OwnerRegisterComponent, RegisterDialogConfig);
  }
  OpenOwnerLoginDialog() {
    this.Dialog.open(OwnersLoginComponent);
  }

  OpenClientRegisterDialog() {
    let RegisterDialogConfig: MatDialogConfig = new MatDialogConfig();
    RegisterDialogConfig.panelClass = "ClientRegisterDialog";
    RegisterDialogConfig.autoFocus = true;
    this.Dialog.open(ClientRegisterComponent, RegisterDialogConfig);
  }
  OpenClientLoginDialog() {
    let ClientLoginDialogConfig: MatDialogConfig = new MatDialogConfig();
    ClientLoginDialogConfig.panelClass = "ClientLoginDiablog";
    ClientLoginDialogConfig.autoFocus = true;
    ClientLoginDialogConfig.maxWidth = "100vw";
    this.Dialog.open(ClientLoginComponent, ClientLoginDialogConfig);
  }
  CLoseRegisterThenOpen_Client_LoginDialog() {
    this.CloseDialog();
    this.OpenClientLoginDialog();
  }

  OpenOwnerForgetPassword() {
    this.Dialog.open(OwnerForgetPasswordComponent);
  }

  OpenClientForgetPassword() {
    this.Dialog.open(ClientForgetPasswordComponent);
  }
  OpenClientResetPassword() {
    this.Dialog.open(ClientResetPasswordComponent);
  }
  OpenOwnerResetPassword() {
    this.Dialog.open(OwnerResetPasswordComponent);
  }
  CLoseRegisterThenOpen_Owner_LoginDialog() {
    this.CloseDialog();
    this.OpenOwnerLoginDialog();
  }
  CloseDialog() {
    this.Dialog.closeAll();
  }
}
