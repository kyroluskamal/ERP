import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { MediaChange, MediaObserver } from '@angular/flex-layout';
import { MatBottomSheet } from '@angular/material/bottom-sheet';
import { NavigationStart, Router } from '@angular/router';
import { Subscription } from 'rxjs/internal/Subscription';
import { TranslationService } from 'src/CommonServices/translation-service.service';
import { ConstantsService } from '../../../../CommonServices/constants.service';
import { DialogHandlerService } from '../../../../CommonServices/DialogHandler/dialog-handler.service';
import { ClientAccountService } from '../../Authentication/client-account-service.service';

@Component({
  selector: 'app-client-main-domain-nav-bar',
  templateUrl: './client-main-domain-nav-bar.component.html',
  styleUrls: ['./client-main-domain-nav-bar.component.css']
})
export class ClientMainDomainNavBarComponent implements OnInit {
  //Properties
  currentUserName: string | null = null;
  IsloggedIn: boolean = false;

  selected: any;
  isActive = false;
  MediaSubscription: Subscription = new Subscription();
  fxFlex: number = 0;
  toolbarStyle: string = "bg-transparent"
  langSelectionStyle: string = "langSelectorMaidDomainStyle langSelectorMaidDomainStyle-UnStickyToolbar"
  //Constructor
  constructor(public dialogHandler: DialogHandlerService, public accountService: ClientAccountService,
    public bottomSheet: MatBottomSheet, public translate: TranslationService, public Constants: ConstantsService,
    private mediaObserver: MediaObserver, private ClientAccountService: ClientAccountService, private router: Router) {

  }

  @Input("apptitle") title: string = "";
  @Output("LoginClick") loginClick = new EventEmitter()
  ngOnInit(): void {
    this.MediaSubscription = this.mediaObserver.asObservable().subscribe(
      (response: MediaChange[]) => {
        if (response.some(x => x.mqAlias === 'xs')) this.fxFlex = 50;
        else this.fxFlex = 17;
      }
    );

    this.selected = localStorage.getItem('lang');
    if (!this.selected) {
      this.selected = 'end';
      this.switchLang(this.selected);
    } else {
      this.switchLang(this.selected);
    }
    this.getCurrentUser();
    if (localStorage.getItem(this.Constants.Client)) {
      const UserinlocalStorage: any = localStorage.getItem(this.Constants.Client);
      this.accountService.setCurrentUser(UserinlocalStorage);
      this.currentUserName = JSON.parse(UserinlocalStorage).username;
    } else if (sessionStorage.getItem(this.Constants.Client)) {
      const UserinSessionStorage: any = sessionStorage.getItem(this.Constants.Client);
      this.accountService.setCurrentUser(UserinSessionStorage);
      this.currentUserName = JSON.parse(UserinSessionStorage).username;
    }
  }

  getCurrentUser() {
    this.accountService.currentUserOvservable.subscribe(
      user => {
        if (user) {
          this.currentUserName = user.username;
        } else {
          this.currentUserName == null;
        }
      },
      error => console.log(error)
    );

  }
  logOut() {
    this.accountService.logout();
    this.currentUserName = null;
    this.IsloggedIn = false
  }
  OnLoginClick(event: any) {
    this.accountService.currentUserOvservable.subscribe(
      user => {
        if (user) {
          this.IsloggedIn = true;
          this.currentUserName = user.username;
          this.loginClick.emit({ event: event, clientName: this.currentUserName });
        } else {
          this.IsloggedIn = false;
          this.currentUserName == null;
        }
      },
      error => console.log(error)
    );
    this.dialogHandler.OpenClientLoginDialog();

  }
  OnRegisterlick() {
    this.dialogHandler.OpenClientRegisterDialog();
  }

  switchLang(lang: string) {
    this.selected = this.translate.setTranslationLang(lang);
  }
}
