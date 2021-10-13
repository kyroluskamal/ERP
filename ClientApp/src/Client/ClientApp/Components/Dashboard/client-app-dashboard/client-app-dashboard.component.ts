import { Component, ElementRef, HostListener, OnInit, Renderer2, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { NotificationsService } from 'src/CommonServices/NotificationService/notifications.service';
import { ConstantsService } from '../../../../../CommonServices/constants.service';
import { TranslationService } from 'src/CommonServices/translation-service.service';
import { MatSlideToggleChange } from '@angular/material/slide-toggle';
import { ThisReceiver } from '@angular/compiler';

@Component({
  selector: 'app-client-app-dashboard',
  templateUrl: './client-app-dashboard.component.html',
  styleUrls: ['./client-app-dashboard.component.css']
})
export class ClientAppDashboardComponent implements OnInit {
  //Properties ............................................................................
  pinned: boolean;
  dir: 'rtl' | 'ltr';
  FullscreenEnabled: boolean = false;
  Display: string;
  SideNav_Content_class: string;
  ToggleClass: string;
  preventMouseLeave: boolean;
  choosenColor: boolean = false;
  /** Subscription to the Directionality change EventEmitter. */
  ThemeColors = [
    { colorName: "blue", value: "#5c77ff", choosen: false, bg: this.Constants.CSS_blue_bg, color: this.Constants.CSS_blue },
    { colorName: "amber", value: "#ffc107", choosen: false, bg: this.Constants.CSS_amber_bg, color: this.Constants.CSS_amber },
    { colorName: "cyan", value: "#00bcd4", choosen: false, bg: this.Constants.CSS_cyan_bg, color: this.Constants.CSS_cyan },
    { colorName: "deep_organge", value: "#ff5722", choosen: false, bg: this.Constants.CSS_deep_organge_bg, color: this.Constants.CSS_deep_organge },
    { colorName: "deep_purple", value: "#673ab7", choosen: false, bg: this.Constants.CSS_deep_purple_bg, color: this.Constants.CSS_deep_purple },
    { colorName: "green", value: "#4caf50", choosen: false, bg: this.Constants.CSS_green_bg, color: this.Constants.CSS_green },
    { colorName: "organge", value: "#ff9800", choosen: false, bg: this.Constants.CSS_organge_bg, color: this.Constants.CSS_organge },
    { colorName: "pink", value: "#e91e63", choosen: false, bg: this.Constants.CSS_pink_bg, color: this.Constants.CSS_pink },
    { colorName: "purple", value: "#9c27b0", choosen: false, bg: this.Constants.CSS_purple_bg, color: this.Constants.CSS_purple },
    { colorName: "red", value: "#f44336", choosen: false, bg: this.Constants.CSS_red_bg, color: this.Constants.CSS_red },
    { colorName: "teal", value: "#009688", choosen: false, bg: this.Constants.CSS_teal_bg, color: this.Constants.CSS_teal }
  ];
  ThemeAppearence: FormControl = new FormControl();
  SidebarAppeareance: FormControl = new FormControl();
  BodyAppeareance: FormControl = new FormControl();
  ToolbarAppeareance: FormControl = new FormControl();
  DocumentDirection: FormControl = new FormControl();
  SidenavThemeClass: any;
  ToolbarThemeClass: any;
  BodyThemeClass: any;
  SelectedLanguage: any;
  ChoosenThemeColor: any;
  //Constructor............................................................................
  constructor(public Constants: ConstantsService, public translate: TranslationService,
    private Notifications: NotificationsService) {
    if (localStorage.getItem(this.Constants.ChoosenThemeColors)) {
      let temp: any = localStorage.getItem(this.Constants.ChoosenThemeColors)
      this.ChoosenThemeColor = JSON.parse(temp);
    } else {
      this.ChoosenThemeColor = this.ThemeColors[0];
      localStorage.setItem(this.Constants.ChoosenThemeColors, JSON.stringify(this.ChoosenThemeColor));
    }
    //set the direction of the document
    if (localStorage.getItem(this.Constants.dir)) {
      this.dir = localStorage.getItem(this.Constants.dir) === "rtl" ? 'rtl' : 'ltr';
    } else {
      this.dir = 'ltr';
      localStorage.setItem(this.Constants.dir, this.dir);
    }
    this.DocumentDirection.setValue(this.dir);
    this.SelectedLanguage = localStorage.getItem('lang');
    if (!this.SelectedLanguage) {
      this.SelectedLanguage = 'en';
    } else {
      this.SelectedLanguage = localStorage.getItem('lang')
    }
    //All theme color
    if (localStorage.getItem(this.Constants.ThemeAppearence)) {
      this.ThemeAppearence.setValue(localStorage.getItem(this.Constants.ThemeAppearence));
    } else {
      this.ThemeAppearence.setValue('light');
      localStorage.setItem(this.Constants.ThemeAppearence, this.ThemeAppearence.value);
    }
    //set the .............. sidenav .......... dark or light themes
    if (localStorage.getItem(this.Constants.SidebarAppeareance)) {
      this.SidebarAppeareance.setValue(localStorage.getItem(this.Constants.SidebarAppeareance));
    } else {
      this.SidebarAppeareance.setValue('dark');
      localStorage.setItem(this.Constants.SidebarAppeareance, this.SidebarAppeareance.value);
    }
    //set the ........ toolabar .......... dark or ligt theme
    if (localStorage.getItem(this.Constants.ToolbarAppeareance)) {
      this.ToolbarAppeareance.setValue(localStorage.getItem(this.Constants.ToolbarAppeareance));
    } else {
      this.ToolbarAppeareance.setValue('dark');
      localStorage.setItem(this.Constants.ToolbarAppeareance, this.ToolbarAppeareance.value);
    }

    //set the ..... body ......dark or light theme
    if (localStorage.getItem(this.Constants.BodyAppeareance)) {
      this.BodyAppeareance.setValue(localStorage.getItem(this.Constants.BodyAppeareance));
    } else {
      this.BodyAppeareance.setValue('dark');
      localStorage.setItem(this.Constants.BodyAppeareance, this.BodyAppeareance.value);
    }
    //set the fixed ot non fixed sidenav
    if (localStorage.getItem(this.Constants.FixedSidnav)) {
      this.pinned = localStorage.getItem(this.Constants.FixedSidnav) === "false" ? false : true;
    } else {
      this.pinned = false;
      localStorage.setItem(this.Constants.FixedSidnav, String(this.pinned));
    }
    if (this.pinned) {
      this.Display = this.Constants.CSS_display_inline_block;
      this.preventMouseLeave = true;
      this.ToggleClass = this.Constants.CSS_SideNav_FullOpened;
      this.SideNav_Content_class = this.dir === 'rtl' ? this.Constants.CSS_sidenav_content_pin_RTL : this.Constants.CSS_sidenav_content_pin_LTR;
    } else {
      this.Display = this.Constants.CSS_displayNone;
      this.preventMouseLeave = false;
      this.ToggleClass = this.Constants.CSS_SideNav_HalfClosed;
      this.SideNav_Content_class = this.dir === 'rtl' ? this.Constants.CSS_sidenav_content_nonPinned_RTL : this.Constants.CSS_sidenav_content_nonPinned_LTR;
    }
    this.setThemeAppearence(this.BodyAppeareance.value, this.ToolbarAppeareance.value, this.SidebarAppeareance.value);
  }
  //NgOn it .....................................................................
  ngOnInit(): void {

  }

  //Events to toggle the left sidenav
  OnMouseOver() {
    this.ToggleClass = this.Constants.CSS_SideNav_FullOpened;
    this.Display = this.Constants.CSS_display_inline_block;
  }
  OnMouseLeave() {
    if (!this.preventMouseLeave) {
      this.ToggleClass = this.Constants.CSS_SideNav_HalfClosed;
      this.Display = this.Constants.CSS_displayNone;
    }
  }

  PinSideNav() {
    this.pinned = !this.pinned;
    localStorage.setItem(this.Constants.FixedSidnav, String(this.pinned))
    this.pinnedRTLClassSettings();
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
    this.ChoosenThemeColor = this.ThemeColors[index];
    localStorage.setItem(this.Constants.ChoosenThemeColors, JSON.stringify(this.ChoosenThemeColor));
  }


  switchLang(lang: string) {
    this.SelectedLanguage = this.translate.setTranslationLang(lang);
    if (this.translate.isRightToLeft(lang)) {
      this.dir = 'rtl';
      localStorage.setItem(this.Constants.dir, this.dir);
    } else {
      this.dir = 'ltr';
      localStorage.setItem(this.Constants.dir, this.dir);
    }
    this.DocumentDirection.setValue(this.dir);
    this.pinnedRTLClassSettings()
  }

  pinnedRTLClassSettings() {
    if (this.pinned) {
      this.Display = this.Constants.CSS_display_inline_block;
      this.preventMouseLeave = true;
      this.ToggleClass = this.Constants.CSS_SideNav_FullOpened;
      this.SideNav_Content_class = this.dir === 'rtl' ? this.Constants.CSS_sidenav_content_pin_RTL : this.Constants.CSS_sidenav_content_pin_LTR;
    } else {
      this.Display = this.Constants.CSS_displayNone;
      this.preventMouseLeave = false;
      this.ToggleClass = this.Constants.CSS_SideNav_HalfClosed;
      this.SideNav_Content_class = this.dir === 'rtl' ? this.Constants.CSS_sidenav_content_nonPinned_RTL : this.Constants.CSS_sidenav_content_nonPinned_LTR;
    }
  }

  DocumentDirectionToggle(DocumentDirection: string) {
    this.dir = this.DocumentDirection.value;
    localStorage.setItem(this.Constants.dir, this.dir);
    this.pinnedRTLClassSettings();
  }
  /****************************************************************************************
   * ..................................... Theme dark or light toggle......................
   ****************************************************************************************/
  ToolbarAppeareanceToggle(ToolbarAppeareance: string) {
    localStorage.setItem(this.Constants.ToolbarAppeareance, ToolbarAppeareance);
    this.setThemeAppearence(this.BodyAppeareance.value, ToolbarAppeareance, this.SidebarAppeareance.value);
  }

  SidebarAppeareanceToggle(SidebarAppeareance: string) {
    localStorage.setItem(this.Constants.SidebarAppeareance, SidebarAppeareance);
    this.setThemeAppearence(this.BodyAppeareance.value, this.ToolbarAppeareance.value, SidebarAppeareance);
  }
  BodyAppeareanceToggle(BodyAppeareance: string) {
    localStorage.setItem(this.Constants.BodyAppeareance, BodyAppeareance);
    this.setThemeAppearence(BodyAppeareance, this.ToolbarAppeareance.value, this.SidebarAppeareance.value);
  }
  AllThemeDarkOrLight(ThemeAppearence: string) {
    localStorage.setItem(this.Constants.ThemeAppearence, ThemeAppearence)
    this.setThemeAppearence(ThemeAppearence, ThemeAppearence, ThemeAppearence);
  }
  setThemeAppearence(BodyAppeareance: string, ToolbarAppeareance: string, SidebarAppeareance: string) {

    this.BodyThemeClass = BodyAppeareance === "light" ? this.Constants.CSS_light_for_body :
      BodyAppeareance === "dark" ? this.Constants.CSS_Dark_for_body : this.Constants.CSS_light_for_body; localStorage.setItem(this.Constants.BodyThemeClass, this.BodyThemeClass);

    this.ToolbarThemeClass = ToolbarAppeareance === "light" ? this.Constants.CSS_light_for_others :
      ToolbarAppeareance === "dark" ? this.Constants.CSS_dark_for_others : this.Constants.CSS_light_for_others;
    localStorage.setItem(this.Constants.ToolbarThemeClass, this.ToolbarThemeClass);

    this.SidenavThemeClass = SidebarAppeareance === "light" ? this.Constants.CSS_light_for_others :
      SidebarAppeareance === "dark" ? this.Constants.CSS_dark_for_others : this.Constants.CSS_light_for_others;
    localStorage.setItem(this.Constants.ToolbarAppeareance, ToolbarAppeareance);
    localStorage.setItem(this.Constants.BodyAppeareance, BodyAppeareance);
    localStorage.setItem(this.Constants.SidebarAppeareance, SidebarAppeareance);
    this.BodyAppeareance.setValue(BodyAppeareance);
    this.SidebarAppeareance.setValue(SidebarAppeareance);
    this.ToolbarAppeareance.setValue(ToolbarAppeareance);

    if (ToolbarAppeareance === 'light' && BodyAppeareance === "light"
      && (SidebarAppeareance === "dark" || SidebarAppeareance === "light")) {
      this.ThemeAppearence.setValue('light');
      localStorage.setItem(this.Constants.ThemeAppearence, this.ThemeAppearence.value)
    } else if (BodyAppeareance === "dark" || (ToolbarAppeareance === 'dark'
      && BodyAppeareance === "dark" && SidebarAppeareance === "dark")) {
      this.ThemeAppearence.setValue('dark');
      localStorage.setItem(this.Constants.ThemeAppearence, this.ThemeAppearence.value)
    }
  }
}
