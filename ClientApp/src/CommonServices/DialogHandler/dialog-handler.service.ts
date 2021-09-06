import { Injectable } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { ClientLoginComponent } from '../../Client/MainDomain/Components/client-login/client-login.component';
import { ClientRegisterComponent } from '../../Client/MainDomain/Components/client-register/client-register.component';
import { OwnerRegisterComponent } from '../../Owners/Components/owner-register/owner-register.component';
import { OwnersLoginComponent } from '../../Owners/Components/owners-login/owners-login.component';

@Injectable({
  providedIn: 'root'
})
export class DialogHandlerService {

  constructor(public Dialog: MatDialog) { }

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
    this.Dialog.open(ClientLoginComponent);
  }
  CLoseRegisterThenOpen_Client_LoginDialog() {
    this.CloseDialog();
    this.OpenClientLoginDialog();
  }
  CLoseRegisterThenOpen_Owner_LoginDialog() {
    this.CloseDialog();
    this.OpenOwnerLoginDialog();
  }
  CloseDialog() {
    this.Dialog.closeAll();
  }
}
