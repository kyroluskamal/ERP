import { Component, Input, OnInit } from '@angular/core';
import { MatBottomSheet } from '@angular/material/bottom-sheet';
import { LocalStorage } from '@ngx-pwa/local-storage';
import { TranslateService } from '@ngx-translate/core';
import { DialogHandlerService } from '../../../../CommonServices/DialogHandler/dialog-handler.service';
import { Constants } from '../../../../Helpers/constants';
import { ClientAccountService } from '../../Authentication/client-account-service.service';

@Component({
  selector: 'app-client-main-domain-nav-bar',
  templateUrl: './client-main-domain-nav-bar.component.html',
  styleUrls: ['./client-main-domain-nav-bar.component.css']
})
export class ClientMainDomainNavBarComponent implements OnInit {
//Properties
  currentUserName: string = ""
  IsloggedIn: boolean = false;
  selected: any;
//Constructor
  constructor(public dialogHandler: DialogHandlerService, private accountService: ClientAccountService,
    public bottomSheet: MatBottomSheet, public translate: TranslateService,
    private localStorage: LocalStorage) {
    translate.addLangs(['en', 'ar']);
    //translate.setDefaultLang(this.selected);
  }

  @Input("apptitle") title: string = "";
  ngOnInit(): void {
    this.selected = localStorage.getItem('lang');
    if (!this.selected) {
      this.selected = "en";
      this.switchLang(this.selected);
    } else {
      this.switchLang(this.selected);
    }

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

  switchLang(lang: string) {
    this.translate.use(lang);
    localStorage.setItem("lang", lang);
    this.selected = lang;
  }
}
