import { ViewportScroller } from '@angular/common';
import { Component, ElementRef, HostListener, Input, OnInit, Renderer2, ViewChild } from '@angular/core';
import { MediaChange, MediaObserver } from '@angular/flex-layout';
import { MatBottomSheet } from '@angular/material/bottom-sheet';
import { MatToolbar } from '@angular/material/toolbar';
import { Subscription } from 'rxjs/internal/Subscription';
import { TranslationService } from 'src/CommonServices/translation-service.service';
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
  isActive = false;
  MediaSubscription: Subscription = new Subscription();
  fxFlex: number=0;
  toolbarStyle: string="bg-transparent"
  langSelectionStyle: string = "langSelectorMaidDomainStyle langSelectorMaidDomainStyle-UnStickyToolbar"
//Constructor
  constructor(public dialogHandler: DialogHandlerService, private accountService: ClientAccountService,
    public bottomSheet: MatBottomSheet, public translate: TranslationService,
    private mediaObserver: MediaObserver, private viewportScroller: ViewportScroller
    ) {
    }

  @Input("apptitle") title: string = "";
  ngOnInit(): void {
    this.MediaSubscription = this.mediaObserver.asObservable().subscribe(
      (response: MediaChange[]) => {
        if(response.some(x=>x.mqAlias==='xs')) this.fxFlex=50;
        else this.fxFlex=17;
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
    this.selected = this.translate.setTranslationLang(lang);
  }
}
