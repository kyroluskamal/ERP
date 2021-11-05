import { ViewportScroller } from '@angular/common';
import { ThrowStmt } from '@angular/compiler';
import { ChangeDetectorRef, ElementRef, HostListener, Renderer2, ViewChild } from '@angular/core';
import { AfterViewInit } from '@angular/core';
import { OnDestroy } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { MediaChange, MediaObserver } from '@angular/flex-layout';
import { Subscription } from 'rxjs';
import { DialogHandlerService } from 'src/CommonServices/DialogHandler/dialog-handler.service';
import { TranslationService } from '../../../../CommonServices/translation-service.service';
import { ClientMainDomainNavBarComponent } from '../client-main-domain-nav-bar/client-main-domain-nav-bar.component';
import { ConstantsService } from 'src/CommonServices/constants.service';
import { NavigationStart, Router } from '@angular/router';
import { ClientAccountService } from '../../Authentication/client-account-service.service';
import { RouterConstants } from 'src/Helpers/RouterConstants';
@Component({
  selector: 'app-client-main-domain-body',
  templateUrl: './client-main-domain-body.component.html',
  styleUrls: ['./client-main-domain-body.component.css']
})
export class ClientMainDomainBodyComponent implements OnInit, OnDestroy {
  //Properties
  selected: any;
  LangSubscibtion: Subscription = new Subscription();
  MediaSubscription: Subscription = new Subscription();
  FirstSec_Header_fontSize: string = '';
  FirstSec_Header_LineSpace: string = '';
  gridCols: number = 3;
  currentUserName: string | null = null;

  UrlWithSubdomain: string = "";

  //constructor
  constructor(public translate: TranslationService, private viewportScroller: ViewportScroller,
    private mediaObserver: MediaObserver, public dialogHandler: DialogHandlerService,
    public Constants: ConstantsService, private router: Router, public accountService: ClientAccountService,) {
    this.selected = localStorage.getItem(this.Constants.lang);

  }

  ngOnInit(): void {
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
    this.MediaSubscription = this.mediaObserver.asObservable().subscribe(
      (response: MediaChange[]) => {
        if (response.some(x => x.mqAlias === 'xs')) {
          this.FirstSec_Header_fontSize = '2.5rem';
          this.FirstSec_Header_LineSpace = '50px';
          this.gridCols = 1;
        } else {
          this.FirstSec_Header_fontSize = '5rem';
          this.FirstSec_Header_LineSpace = '80px';
          this.gridCols = 3;
        };
      }
    );
    this.LangSubscibtion = this.translate.SelectedLangSubject.subscribe(
      (response:any) => {
        this.selected = response;
      }
    );
  }
  ngOnDestroy(): void {
    this.LangSubscibtion.unsubscribe();
    this.MediaSubscription.unsubscribe();
  }


  @ViewChild('MainDomainToolbar') ClientNavBar: ClientMainDomainNavBarComponent = {} as ClientMainDomainNavBarComponent;

  @HostListener('window:load')
  onWindowLoad() {
    this.viewportScroller.setOffset([0, 0]);
  }
  @HostListener('window:scroll')
  onWindowScroll() {
    if (this.viewportScroller.getScrollPosition()[1] > 200) {
      this.ClientNavBar.toolbarStyle = `${this.Constants.CSS_ToolBar} ${this.Constants.CSS_mat_elevation_z9}`;
    } else {
      this.ClientNavBar.toolbarStyle = "";
    }
  }
  OnloginClick(value: any) {
    if (value.clientName != null) {
      this.router.navigateByUrl(`/${RouterConstants.Client_MainDomainAccountURL}`);
      this.currentUserName = value.clientName;
    }
  }
  OnLogoutClick(value: any) {

    this.currentUserName = value.clientName;
    console.log(value);
  }
}
