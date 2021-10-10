import { Component, ElementRef, HostListener, OnInit, ViewChild } from '@angular/core';
import { NotificationsService } from 'src/CommonServices/NotificationService/notifications.service';
import { ConstantsService } from '../../../../../CommonServices/constants.service';
@Component({
  selector: 'app-client-app-dashboard',
  templateUrl: './client-app-dashboard.component.html',
  styleUrls: ['./client-app-dashboard.component.css']
})
export class ClientAppDashboardComponent implements OnInit {
  pinned: boolean;
  FullscreenEnabled: boolean = false;
  Display: string = this.Constants.CSS_displayNone;
  SideNav_Content_class = this.Constants.CSS_sidenav_content_initial;
  fixedSideNavToggle: string = this.Constants.CSS_SideNav_HalfClosed;
  ToggleClass: string = this.Constants.CSS_SideNav_fullyClosed;
  preventMouseLeave: boolean = false;
  constructor(public Constants: ConstantsService, private Notifications: NotificationsService) {
    let pinnedInLocalStorage = localStorage.getItem(this.Constants.FixedSidnav);
    console.log(pinnedInLocalStorage);
    if (pinnedInLocalStorage) {
      this.pinned = Boolean(pinnedInLocalStorage);
    } else {
      this.pinned = false;
      localStorage.setItem(this.Constants.FixedSidnav, String(this.pinned))
    }

    if (this.pinned) {
      this.preventMouseLeave = true;
      this.ToggleClass = this.Constants.CSS_SideNav_FullOpened;
      this.SideNav_Content_class = this.Constants.CSS_sidenav_content_pin
    } else {
      this.preventMouseLeave = false;
      this.ToggleClass = this.Constants.CSS_SideNav_fullyClosed;
      this.SideNav_Content_class = this.Constants.CSS_sidenav_content_initial;
    }
  }

  ngOnInit(): void {

  }

  OnMouseOver() {
    this.ToggleClass = this.Constants.CSS_SideNav_FullOpened;
  }
  OnMouseLeave() {
    if (!this.preventMouseLeave) {
      this.ToggleClass = this.Constants.CSS_SideNav_fullyClosed;
      this.fixedSideNavToggle = this.Constants.CSS_SideNav_HalfClosed;
    }
  }

  PinSideNav() {

    this.pinned = !this.pinned;
    localStorage.setItem(this.Constants.FixedSidnav, String(this.pinned))
    if (this.pinned) {
      this.preventMouseLeave = true;
      this.ToggleClass = this.Constants.CSS_SideNav_FullOpened;
      this.SideNav_Content_class = this.Constants.CSS_sidenav_content_pin
    } else {
      this.preventMouseLeave = false;
      this.ToggleClass = this.Constants.CSS_SideNav_fullyClosed;
      this.SideNav_Content_class = this.Constants.CSS_sidenav_content_initial;
    }
  }

  ToggleFullscreen() {
    if (!document.fullscreenEnabled) {
      this.Notifications.error("Your browser doesn't support fullscreen mode. Use latest version of Chrome.", "");
    } else {
      if (!document.fullscreenElement) {
        document.documentElement.requestFullscreen()
      }
      else {
        document.exitFullscreen();
      }
    }
  }

  //Only to toggle fullscreen ICON
  @HostListener("window:resize")
  ToggleFullScreenIcon() {
    this.FullscreenEnabled = !this.FullscreenEnabled;
  }
}
