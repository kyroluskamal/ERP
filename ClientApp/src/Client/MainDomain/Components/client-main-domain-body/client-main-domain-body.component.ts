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

import 'aos/dist/aos.css';
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
  test: any;
  NavigateToAccount: any = "/account";
  localStorageSubscription: Subscription = new Subscription();
  SessionStorageSubscription: Subscription = new Subscription();
  //constructor
  constructor(public translate: TranslationService, private viewportScroller: ViewportScroller,
    private mediaObserver: MediaObserver, public dialogHandler: DialogHandlerService,
    public Constants: ConstantsService, private router: Router, private ClientAccountService: ClientAccountService) {
    this.selected = localStorage.getItem(this.Constants.lang);
  }

  ngOnInit(): void {
    this.MediaSubscription = this.mediaObserver.asObservable().subscribe(
      (response: MediaChange[]) => {
        if (response.some(x => x.mqAlias === 'xs')) {
          this.FirstSec_Header_fontSize = '2rem';
          this.FirstSec_Header_LineSpace = '30px';
          this.gridCols = 1;
        } else {
          this.FirstSec_Header_fontSize = '5rem';
          this.FirstSec_Header_LineSpace = '80px';
          this.gridCols = 3;
        };
      }
    );
    this.LangSubscibtion = this.translate.SelectedLangSubject.subscribe(
      (response) => {
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
      this.ClientNavBar.langSelectionStyle = "langSelectorMaidDomainStyle langSelectorMaidDomainStyle-StickyToolbar"
      this.ClientNavBar.toolbarStyle = "ToolBar mat-elevation-z9";
    } else {
      this.ClientNavBar.toolbarStyle = "bg-transparent";
      this.ClientNavBar.langSelectionStyle = "langSelectorMaidDomainStyle langSelectorMaidDomainStyle-UnStickyToolbar"

    }
  }
  OnloginClick(value: any) {
    if (value.clientName != null) {
      console.log("clieded hererer")
      this.router.navigateByUrl(`/${RouterConstants.Client_MainDomainAccountURL}`);
    }
  }

}
