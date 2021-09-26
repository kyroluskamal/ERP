import { ViewportScroller } from '@angular/common';
import { ThrowStmt } from '@angular/compiler';
import { ChangeDetectorRef, HostListener, Renderer2, ViewChild } from '@angular/core';
import { AfterViewInit } from '@angular/core';
import { OnDestroy } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { MediaChange, MediaObserver } from '@angular/flex-layout';
import { Subscription } from 'rxjs';
import { DialogHandlerService } from 'src/CommonServices/DialogHandler/dialog-handler.service';
import { Constants } from 'src/Helpers/constants';
import { TranslationService } from '../../../../CommonServices/translation-service.service';
import { ClientMainDomainNavBarComponent } from '../client-main-domain-nav-bar/client-main-domain-nav-bar.component';

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
  //constructor
  constructor(public translate: TranslationService, private cdRef: ChangeDetectorRef, private viewportScroller: ViewportScroller,
    private mediaObserver: MediaObserver, public dialogHandler: DialogHandlerService, private renderer: Renderer2) {
    this.selected = localStorage.getItem(Constants.lang);
  }
  @ViewChild('MainDomainToolbar') ClientNavBar: ClientMainDomainNavBarComponent = {} as ClientMainDomainNavBarComponent;

  @HostListener('window:load')
  onWindowLoad() {
    this.viewportScroller.setOffset([0, 0]);
  }
  @HostListener('window:scroll')
  onWindowScroll() {
    console.log(this.viewportScroller.getScrollPosition());
    if (this.viewportScroller.getScrollPosition()[1] > 200) {
      this.ClientNavBar.langSelectionStyle = "langSelectorMaidDomainStyle langSelectorMaidDomainStyle-StickyToolbar"
      this.ClientNavBar.toolbarStyle = "ToolBar mat-elevation-z9";
    } else {
      this.ClientNavBar.toolbarStyle = "bg-transparent";
      this.ClientNavBar.langSelectionStyle = "langSelectorMaidDomainStyle langSelectorMaidDomainStyle-UnStickyToolbar"

    }
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
}
