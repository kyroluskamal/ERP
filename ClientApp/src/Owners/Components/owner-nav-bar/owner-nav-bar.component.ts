import { Component, Input, OnInit } from '@angular/core';
import { MatBottomSheet } from '@angular/material/bottom-sheet';
import { DialogHandlerService } from '../../../CommonServices/DialogHandler/dialog-handler.service';
import { Constants } from '../../../Helpers/constants';
import { OwnerAccountService } from '../../Services/Authentication/Owner-account-service.service';
@Component({
  selector: 'app-owner-nav-bar',
  templateUrl: './owner-nav-bar.component.html',
  styleUrls: ['./owner-nav-bar.component.css']
})
export class OwnerNavBarComponent implements OnInit {
  constructor(public dialogHandler: DialogHandlerService, public bottomSheet: MatBottomSheet,
    private accountService: OwnerAccountService) { }
  currentUserName: string = "";
  IsloggedIn: boolean = false;
  @Input("apptitle") title: string = "";
  ngOnInit(): void {
    this.getCurrentUser();
    if (localStorage.getItem(Constants.Owner)) {
      const UserinlocalStorage: any = localStorage.getItem(Constants.Owner);
      this.accountService.setCurrentUser(UserinlocalStorage);
      this.currentUserName = JSON.parse(UserinlocalStorage).username;
      this.IsloggedIn = true;
    } else if (sessionStorage.getItem(Constants.Owner)) {
      const UserinSessionStorage: any = sessionStorage.getItem(Constants.Owner);
      this.accountService.setCurrentUser(UserinSessionStorage);
      this.currentUserName = JSON.parse(UserinSessionStorage).username;
      this.IsloggedIn = true;
    }
    this.getCurrentUser();
  }

  OnLoginClick() {
    this.dialogHandler.OpenOwnerLoginDialog();
  }
  OnRegisterlick() {
    this.dialogHandler.OpenOwnerRegisterDialog();
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
}
