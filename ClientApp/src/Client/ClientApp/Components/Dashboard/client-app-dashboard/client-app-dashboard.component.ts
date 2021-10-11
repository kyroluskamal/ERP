import { Component, ElementRef, HostListener, OnInit, Renderer2, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { NotificationsService } from 'src/CommonServices/NotificationService/notifications.service';
import { ConstantsService } from '../../../../../CommonServices/constants.service';
import { Directionality } from '@angular/cdk/bidi';
import { Subscription } from 'rxjs/internal/Subscription';

@Component({
  selector: 'app-client-app-dashboard',
  templateUrl: './client-app-dashboard.component.html',
  styleUrls: ['./client-app-dashboard.component.css']
})
export class ClientAppDashboardComponent implements OnInit {
  //Properties ............................................................................
  pinned: boolean;
  IsRTL: boolean;
  FullscreenEnabled: boolean = false;
  Display: string = this.Constants.CSS_displayNone;
  SideNav_Content_class = this.Constants.CSS_sidenav_content_initial;
  fixedSideNavToggle: string = this.Constants.CSS_SideNav_HalfClosed;
  ToggleClass: string = this.Constants.CSS_SideNav_fullyClosed;
  preventMouseLeave: boolean = false;
  choosenColor: boolean = false;
  /** Subscription to the Directionality change EventEmitter. */
  private _dirChangeSubscription = Subscription.EMPTY;
  ThemeColors = [
    { colorName: "amber", value: "#ffc107", choosen: false },
    { colorName: "blue", value: "#5c77ff", choosen: false },
    { colorName: "cyan", value: "#00bcd4", choosen: false },
    { colorName: "deep_organge", value: "#ff5722", choosen: false },
    { colorName: "deep_purple", value: "#673ab7", choosen: false },
    { colorName: "green", value: "#4caf50", choosen: false },
    { colorName: "organge", value: "#ff9800", choosen: false },
    { colorName: "pink", value: "#e91e63", choosen: false },
    { colorName: "purple", value: "#9c27b0", choosen: false },
    { colorName: "red", value: "#f44336", choosen: false },
    { colorName: "teal", value: "#009688", choosen: false }
  ];
  ThemeAppearence: FormControl = new FormControl();
  SidenavThemeClass: any;
  ToolbarThemeClass: any;
  BodyThemeClass: any;

  @ViewChild("themeColorPicker", { static: false }) themeColorPicker: ElementRef<HTMLParagraphElement> = {} as ElementRef<HTMLParagraphElement>;
  //Constructor............................................................................
  constructor(public Constants: ConstantsService, dir: Directionality,
    private Notifications: NotificationsService) {
    this.IsRTL = dir.value === "rtl";
    this._dirChangeSubscription = dir.change.subscribe(() => {
      this.flipDirection();
    })
    if (localStorage.getItem(this.Constants.SideNavThemeClass)) {
      this.SidenavThemeClass = localStorage.getItem(this.Constants.SideNavThemeClass)

    } else {
      this.SidenavThemeClass = this.Constants.CSS_Dark;
      localStorage.setItem(this.Constants.SideNavThemeClass, this.SidenavThemeClass);
    }
    if (localStorage.getItem(this.Constants.ToolbarThemeClass)) {
      this.ToolbarThemeClass = localStorage.getItem(this.Constants.ToolbarThemeClass)
    } else {
      this.ToolbarThemeClass = this.Constants.CSS_light_White_bg;
      localStorage.setItem(this.Constants.ToolbarThemeClass, this.ToolbarThemeClass);
    }
    if (localStorage.getItem(this.Constants.BodyThemeClass)) {
      this.BodyThemeClass = localStorage.getItem(this.Constants.BodyThemeClass)
    } else {
      this.BodyThemeClass = this.Constants.CSS_light;
      localStorage.setItem(this.Constants.BodyThemeClass, this.BodyThemeClass);
    }

    if (localStorage.getItem(this.Constants.FixedSidnav)) {
      this.pinned = localStorage.getItem(this.Constants.FixedSidnav) === "false" ? false : true;
    } else {
      this.pinned = false;
      localStorage.setItem(this.Constants.FixedSidnav, String(this.pinned))
    }
    console.log(this.pinned);
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
  //NgOn it .....................................................................
  ngOnInit(): void {

  }

  //Events to toggle the left sidenav
  OnMouseOver() { this.ToggleClass = this.Constants.CSS_SideNav_FullOpened; }
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
    if (!document.fullscreenEnabled)
      this.Notifications.error("Your browser doesn't support fullscreen mode. Use latest version of Chrome.", "");
    else if (!document.fullscreenElement) document.documentElement.requestFullscreen()
    else { document.exitFullscreen() }
  }

  //Only to toggle fullscreen ICON ...........................................................................
  @HostListener("window:resize") ToggleFullScreenIcon() { this.FullscreenEnabled = !this.FullscreenEnabled; }

  ColorChoose(colorName: string, index: number) {
    for (let x of this.ThemeColors) {
      if (x.colorName === colorName) x.choosen = true;
      else x.choosen = false
    }
  }

  DarkOrLight() {
    console.log(this.ThemeAppearence.value);
    this.BodyThemeClass = this.ThemeAppearence.value;
    localStorage.setItem(this.Constants.BodyThemeClass, this.BodyThemeClass);

    this.ToolbarThemeClass = this.ThemeAppearence.value === "light" ? this.Constants.CSS_light_White_bg :
      this.ThemeAppearence.value === "dark" ? this.Constants.CSS_Dark : this.Constants.CSS_light_White_bg;
    localStorage.setItem(this.Constants.ToolbarThemeClass, this.ToolbarThemeClass);

    this.SidenavThemeClass = this.ThemeAppearence.value === "light" ? this.Constants.CSS_light_White_bg :
      this.ThemeAppearence.value === "dark" ? this.Constants.CSS_Dark : this.Constants.CSS_light_White_bg;
    localStorage.setItem(this.Constants.SideNavThemeClass, this.SidenavThemeClass);
  }

  RTLToggle() {
    this.IsRTL = !this.IsRTL;
    if (this.IsRTL) {
      document.dir = "rtl";
    } else document.dir = "ltr";
  }
}
