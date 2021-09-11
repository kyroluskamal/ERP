import { Component, Input, OnInit } from '@angular/core';
import { MatBottomSheet } from '@angular/material/bottom-sheet';
import { DialogHandlerService } from '../../../../CommonServices/DialogHandler/dialog-handler.service';
import { Constants } from '../../../../Helpers/constants';
import { ClientAccountService } from '../../../Services/Authentication/client-account-service.service';

@Component({
  selector: 'app-client-main-domain-nav-bar',
  templateUrl: './client-main-domain-nav-bar.component.html',
  styleUrls: ['./client-main-domain-nav-bar.component.css']
})
export class ClientMainDomainNavBarComponent implements OnInit {
  currentUserName: string = ""
  IsloggedIn: boolean = false;
  constructor(public dialogHandler: DialogHandlerService, private accountService: ClientAccountService,
    public bottomSheet: MatBottomSheet) { }

  @Input("apptitle") title: string = "";
  ngOnInit(): void {
    this.getCurrentUser();
    if (localStorage.getItem(Constants.Client)) {
      const UserinlocalStorage: any = localStorage.getItem(Constants.Client);
      this.accountService.setCurrentUser(UserinlocalStorage);
      this.currentUserName = JSON.parse(UserinlocalStorage).username;
      this.IsloggedIn = true;
    } else if (sessionStorage.getItem(Constants.Client)) {
      const UserinSessionStorage: any = sessionStorage.getItem(Constants.Client);
      this.accountService.setCurrentUser(UserinSessionStorage);
      this.currentUserName = JSON.parse(UserinSessionStorage).username;
      this.IsloggedIn = true;
    }
    
  }

  getCurrentUser() {
    this.accountService.currentUserOvservable.subscribe(
      user => {
        this.IsloggedIn = !!user;
        this.currentUserName = user.username;
      },
      error => console.log(error)
    );
  }
  logOut() {
    this.accountService.logout();
  }
  OnLoginClick() {
    this.dialogHandler.OpenClientLoginDialog();
  }
  OnRegisterlick() {
    this.dialogHandler.OpenClientRegisterDialog();
  }

}
