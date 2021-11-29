import { Component, Input, OnInit, Output, EventEmitter, OnDestroy } from '@angular/core';
import { MediaChange, MediaObserver } from '@angular/flex-layout';
import { MatBottomSheet } from '@angular/material/bottom-sheet';
import { NavigationEnd, NavigationStart, Router } from '@angular/router';
import { Subscription } from 'rxjs/internal/Subscription';
import { filter } from 'rxjs/operators';
import { ClientAccountService } from 'src/Client/MainDomain/Authentication/client-account-service.service';
import { ConstantsService } from 'src/CommonServices/constants.service';
import { DialogHandlerService } from 'src/CommonServices/DialogHandler/dialog-handler.service';
import { TranslationService } from 'src/CommonServices/translation-service.service';
import { RouterConstants } from 'src/Helpers/RouterConstants';


@Component({
  selector: 'app-client-app-home-navbar',
  templateUrl: './client-app-home-navbar.component.html',
  styleUrls: ['./client-app-home-navbar.component.css']
})
export class ClientAppHomeNavbarComponent implements OnInit {

  //Properties
  currentUserName: string | null = null;
  IsloggedIn: boolean = false;
  HomeButtonActive: string = "btn btn-neutral";
  DashboardButtonActive: string = "";
  selected: any;
  isActive = false;
  MediaSubscription: Subscription = new Subscription();
  fxFlex: number = 0;
  toolbarStyle: string = "";
  routerSubscribtion: Subscription = new Subscription();
  SubomainFromLogin: string = "";
  UrlWithSubdomain: string = "";
  //Constructor
  constructor(public dialogHandler: DialogHandlerService, public accountService: ClientAccountService,
    public bottomSheet: MatBottomSheet, public translate: TranslationService, public Constants: ConstantsService,
    private mediaObserver: MediaObserver, private router: Router) {
    this.routerSubscribtion = this.router.events.pipe(
      filter(e => e instanceof NavigationEnd)
    )
      .subscribe((navEnd: any) => {
        if (navEnd.url.length === 1) this.HomeButtonActive = "btn btn-neutral";
        else this.HomeButtonActive = ""
        if (navEnd.url.includes("/dashboard")) this.DashboardButtonActive = "btn btn-neutral";
        else this.DashboardButtonActive = "";
      });
  }
  // ngOnDestroy(): void {
  //   this.routerSubscribtion.unsubscribe();
  // }

  @Input("apptitle") title: string = "";
  @Output("LoginClick") loginClick = new EventEmitter()
  @Output("LogOutClick") LogOutClick = new EventEmitter()
  ngOnInit(): void {

    console.log(this.HomeButtonActive)
    this.MediaSubscription = this.mediaObserver.asObservable().subscribe(
      (response: MediaChange[]) => {
        if (response.some(x => x.mqAlias === 'xs')) this.fxFlex = 50;
        else this.fxFlex = 17;
      }
    );

    this.selected = localStorage.getItem('lang');
    if (!this.selected) {
      this.selected = 'en';
      this.switchLang(this.selected);
    } else {
      this.switchLang(this.selected);
    }
    this.getCurrentUser();
    if (localStorage.getItem(this.Constants.Client)) {
      let UserinlocalStorage: any = localStorage.getItem(this.Constants.Client);
      UserinlocalStorage = JSON.parse(UserinlocalStorage);
      this.accountService.setCurrentUser(UserinlocalStorage);
      this.currentUserName = UserinlocalStorage.username;
      this.SubomainFromLogin = UserinlocalStorage.subdomain;
      this.UrlWithSubdomain = `https://${UserinlocalStorage.subdomain}.${window.location.host}`;
      console.log(this.UrlWithSubdomain);
    } else if (sessionStorage.getItem(this.Constants.Client)) {
      let UserinSessionStorage: any = sessionStorage.getItem(this.Constants.Client);
      UserinSessionStorage = JSON.parse(UserinSessionStorage);
      this.accountService.setCurrentUser(UserinSessionStorage);
      this.currentUserName = UserinSessionStorage.username;
      this.SubomainFromLogin = UserinSessionStorage.Subdomain;
      this.UrlWithSubdomain = `https://${UserinSessionStorage.subdomain}.${window.location.host}`;
    }
  }

  getCurrentUser() {
    this.accountService.currentUserOvservable.subscribe(
      user => {
        if (user) {
          this.currentUserName = user.username;
          this.UrlWithSubdomain = `https://${user.subdomain}.${window.location.host}`;
        } else {
          this.currentUserName == null;
        }
      },
      error => console.log(error)
    );

  }
  logOut(event: any) {
    this.accountService.logout();
    this.currentUserName = null;
    this.LogOutClick.emit({ event: event, clientName: this.currentUserName })
    this.router.navigateByUrl("/");
  }
  OnLoginClick(event: any) {
    this.accountService.currentUserOvservable.subscribe(
      user => {
        if (user) {
          this.IsloggedIn = true;
          this.currentUserName = user.username;
          this.SubomainFromLogin = user.subdomain;
          this.loginClick.emit({ event: event, clientName: this.currentUserName });
        } else {
          this.IsloggedIn = false;
          this.currentUserName == null;
          this.SubomainFromLogin = ""
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
