import { AfterContentInit, Component, ElementRef, HostListener, OnDestroy, OnInit, RendererStyleFlags2, ViewChild, ViewEncapsulation } from '@angular/core';
import { FormControl } from '@angular/forms';
import { NotificationsService } from 'src/CommonServices/NotificationService/notifications.service';
import { ConstantsService } from '../../../../../CommonServices/constants.service';
import { TranslationService } from 'src/CommonServices/translation-service.service';
import { routerAnimation } from '../DashboardAnimations/Animations'
import { MatDrawerMode } from '@angular/material/sidenav';
import { filter, Subscription } from 'rxjs';
import { MediaChange, MediaObserver } from '@angular/flex-layout';
import { NavigationEnd, Router, RouterOutlet } from '@angular/router';
import { SideNav_items } from '.././SideNavItems'
import { LightDarkThemeConverterService } from '../light-dark-theme-converter.service';
import { ClientAccountService } from 'src/Client/MainDomain/Authentication/client-account-service.service';
import { ExpansionPanel, ThemeColor } from 'src/Interfaces/interfaces';



@Component({
  selector: 'app-client-app-dashboard',
  templateUrl: './client-app-dashboard.component.html',
  styleUrls: ['./client-app-dashboard.component.css'],
  encapsulation: ViewEncapsulation.None,
  animations: [routerAnimation]
})
export class ClientAppDashboardComponent implements OnInit, AfterContentInit, OnDestroy {
  //#region Properties
  //Properties ............................................................................
  pinned: boolean;
  dir: 'rtl' | 'ltr';
  agGridTable_dir: 'rtl' | 'ltr';
  FullscreenEnabled: boolean = false;
  Display: string;
  SideNav_Content_class: string;
  ToggleClass: string;
  preventMouseLeave: boolean;
  choosenColor: boolean = false;
  SideNav_openingStatus: boolean = true;
  SideNav_mode: MatDrawerMode = "side";

  hasBackDrop: boolean = false;
  //#endregion
  /** Subscription to the Directionality change EventEmitter. */

  //#region ThemeColors
  ThemeColors: ThemeColor[] = [
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
  //#endregion
  ThemeAppearence: FormControl = new FormControl();
  TableAppearence: FormControl = new FormControl();
  SidebarAppeareance: FormControl = new FormControl();
  BodyAppeareance: FormControl = new FormControl();
  ToolbarAppeareance: FormControl = new FormControl();
  DocumentDirection: FormControl = new FormControl();
  agGridTableDirection: FormControl = new FormControl();
  SidenavThemeClass: any;
  ToolbarThemeClass: any;
  BodyThemeClass: any;
  SelectedLanguage: any;
  ChoosenThemeColor: any;
  MediaSubscription: Subscription = new Subscription();
  Table_color_mode: string;
  @ViewChild("SideNavToggleButtonOnSmallScreen", { read: ElementRef }) SideNavToggleButtonOnSmallScreen: ElementRef<HTMLButtonElement> = {} as ElementRef<HTMLButtonElement>;
  @ViewChild("pinButton", { read: ElementRef }) pinButton: ElementRef<HTMLButtonElement> = {} as ElementRef<HTMLButtonElement>;
  @ViewChild("FullscreenButton", { read: ElementRef }) FullscreenButton: ElementRef<HTMLButtonElement> = {} as ElementRef<HTMLButtonElement>;
  SideNavItems: ExpansionPanel[] = SideNav_items;

  //#region Constructor
  //Constructor............................................................................
  constructor(public Constants: ConstantsService, public translate: TranslationService,
    private Notifications: NotificationsService, private mediaObserver: MediaObserver,
    private ClientAccountService: ClientAccountService,
    private LightDarkThemeConverter: LightDarkThemeConverterService, private router: Router) {
    this.ClientAccountService.currentUserOvservable.subscribe(
      r => console.log(r)
    );

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
    this.LightDarkThemeConverter.PassThemeDir(this.dir);
    this.DocumentDirection.setValue(this.dir);
    //Set Ag-grid table direction
    if (localStorage.getItem(this.Constants.Table_direction)) {
      this.agGridTable_dir = localStorage.getItem(this.Constants.Table_direction) === 'rtl' ? 'rtl' : 'ltr';
    } else {
      this.agGridTable_dir = 'ltr';
      localStorage.setItem(this.Constants.Table_direction, this.agGridTable_dir);
    }
    this.agGridTableDirection.setValue(this.agGridTable_dir);
    this.LightDarkThemeConverter.ChangeAgGridTable_dir(this.agGridTable_dir);

    //Set Ag-grid dark or light mode
    if (localStorage.getItem(this.Constants.Table_Color_mode)) {
      this.Table_color_mode = localStorage.getItem(this.Constants.Table_Color_mode) === this.Constants.light ?
        this.Constants.light : this.Constants.dark;
      this.TableAppearence.setValue(this.Table_color_mode);

    } else {
      this.Table_color_mode = this.Constants.light;
      localStorage.setItem(this.Constants.Table_Color_mode, this.Table_color_mode);
    }
    this.TableAppearence.setValue(this.Table_color_mode);
    this.LightDarkThemeConverter.ChangeTableTheme(this.Table_color_mode);
    //get selected language
    this.SelectedLanguage = localStorage.getItem(this.Constants.lang);
    if (!this.SelectedLanguage) {
      this.SelectedLanguage = 'en';
    } else {
      this.SelectedLanguage = localStorage.getItem(this.Constants.lang)
    }
    //All theme color
    if (localStorage.getItem(this.Constants.ThemeAppearence)) {
      this.ThemeAppearence.setValue(localStorage.getItem(this.Constants.ThemeAppearence));
    } else {
      this.ThemeAppearence.setValue(this.Constants.light);
      localStorage.setItem(this.Constants.ThemeAppearence, this.ThemeAppearence.value);
    }
    //set the .............. sidenav .......... dark or light themes
    if (localStorage.getItem(this.Constants.SidebarAppeareance)) {
      this.SidebarAppeareance.setValue(localStorage.getItem(this.Constants.SidebarAppeareance));
    } else {
      this.SidebarAppeareance.setValue(this.Constants.dark);
      localStorage.setItem(this.Constants.SidebarAppeareance, this.SidebarAppeareance.value);
    }
    //set the ........ toolabar .......... dark or ligt theme
    if (localStorage.getItem(this.Constants.ToolbarAppeareance)) {
      this.ToolbarAppeareance.setValue(localStorage.getItem(this.Constants.ToolbarAppeareance));
    } else {
      this.ToolbarAppeareance.setValue(this.Constants.dark);
      localStorage.setItem(this.Constants.ToolbarAppeareance, this.ToolbarAppeareance.value);
    }

    //set the ..... body ......dark or light theme
    if (localStorage.getItem(this.Constants.BodyAppeareance)) {
      this.BodyAppeareance.setValue(localStorage.getItem(this.Constants.BodyAppeareance));
    } else {
      this.BodyAppeareance.setValue(this.Constants.dark);
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
    if (!this.pinned) this.SideNavItems.forEach(i => i.expanded = false);
    this.router.events.pipe(
      filter(event => event instanceof NavigationEnd)
    )
      .subscribe((event: any) => {
        for (let item of this.SideNavItems) {
          for (let link of item.links) {
            if (event.url.split("/").pop() === link.link.split('/').pop()) {
              if (!this.pinned) item.expanded = false;
              else item.expanded = true;
              link.state = true;
            }
            else link.state = false;
          }
        }
      });
    this.setThemeAppearence(this.BodyAppeareance.value, this.ToolbarAppeareance.value, this.SidebarAppeareance.value);
  }
  //#endregion

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
      for (let item of this.SideNavItems) {
        item.expanded = false;
      }
    }
  }

  PinSideNav() {
    this.pinned = !this.pinned;
    localStorage.setItem(this.Constants.FixedSidnav, String(this.pinned))
    this.pinnedRTLClassSettings();

    if (this.pinned === false) {
      for (let item of this.SideNavItems) {
        item.expanded = false;
      }
    }
  }

  ToggleFullscreen() {
    if (!document.fullscreenEnabled)
      this.Notifications.error(this.translate.GetTranslation(this.Constants.BrowserDontSupportFullscreen), "",
        this.translate.isRightToLeft(this.SelectedLanguage) ? "rtl" : "ltr");
    else if (!document.fullscreenElement) document.documentElement.requestFullscreen()
    else { document.exitFullscreen() }
  }

  //Only to toggle fullscreen ICON ...........................................................................
  @HostListener("window:resize") ToggleFullScreenIcon() {
    if (document.fullscreenElement)
      this.FullscreenEnabled = true;
    else
      this.FullscreenEnabled = false;
  }

  ColorChoose(colorName: string, index: number) {
    for (let x of this.ThemeColors) {
      if (x.colorName === colorName) x.choosen = true;
      else x.choosen = false
    }
    this.ChoosenThemeColor = this.ThemeColors[index];
    this.LightDarkThemeConverter.ChangeCurrentColor(this.ChoosenThemeColor);
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

  DocumentDirectionToggle() {
    this.dir = this.DocumentDirection.value;
    localStorage.setItem(this.Constants.dir, this.dir);
    this.LightDarkThemeConverter.PassThemeDir(this.dir);
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
    this.LightDarkThemeConverter.ChangeTheme(BodyAppeareance);
    localStorage.setItem(this.Constants.BodyAppeareance, BodyAppeareance);
    this.setThemeAppearence(BodyAppeareance, this.ToolbarAppeareance.value, this.SidebarAppeareance.value);
  }
  AllThemeDarkOrLight(ThemeAppearence: string) {
    this.LightDarkThemeConverter.ChangeTheme(ThemeAppearence);
    localStorage.setItem(this.Constants.ThemeAppearence, ThemeAppearence)
    this.setThemeAppearence(ThemeAppearence, ThemeAppearence, ThemeAppearence);
  }
  setThemeAppearence(BodyAppeareance: string, ToolbarAppeareance: string, SidebarAppeareance: string) {
    this.LightDarkThemeConverter.ChangeTheme(BodyAppeareance);
    this.BodyThemeClass = BodyAppeareance === this.Constants.light ? this.Constants.CSS_light_for_body :
      BodyAppeareance === this.Constants.dark ? this.Constants.CSS_Dark_for_body : this.Constants.CSS_light_for_body; localStorage.setItem(this.Constants.BodyThemeClass, this.BodyThemeClass);

    this.ToolbarThemeClass = ToolbarAppeareance === this.Constants.light ? this.Constants.CSS_light_for_others :
      ToolbarAppeareance === this.Constants.dark ? this.Constants.CSS_dark_for_others : this.Constants.CSS_light_for_others;
    localStorage.setItem(this.Constants.ToolbarThemeClass, this.ToolbarThemeClass);

    this.SidenavThemeClass = SidebarAppeareance === this.Constants.light ? this.Constants.CSS_light_for_others :
      SidebarAppeareance === this.Constants.dark ? this.Constants.CSS_dark_for_others : this.Constants.CSS_light_for_others;
    localStorage.setItem(this.Constants.ToolbarAppeareance, ToolbarAppeareance);
    localStorage.setItem(this.Constants.BodyAppeareance, BodyAppeareance);
    localStorage.setItem(this.Constants.SidebarAppeareance, SidebarAppeareance);
    this.BodyAppeareance.setValue(BodyAppeareance);
    this.SidebarAppeareance.setValue(SidebarAppeareance);
    this.ToolbarAppeareance.setValue(ToolbarAppeareance);

    if (ToolbarAppeareance === this.Constants.light && BodyAppeareance === this.Constants.light
      && (SidebarAppeareance === this.Constants.dark || SidebarAppeareance === this.Constants.light)) {
      this.ThemeAppearence.setValue(this.Constants.light);
      localStorage.setItem(this.Constants.ThemeAppearence, this.ThemeAppearence.value)
    } else if (BodyAppeareance === this.Constants.dark || (ToolbarAppeareance === this.Constants.dark
      && BodyAppeareance === this.Constants.dark && SidebarAppeareance === this.Constants.dark)) {
      this.ThemeAppearence.setValue(this.Constants.dark);
      localStorage.setItem(this.Constants.ThemeAppearence, this.ThemeAppearence.value)
    }
  }
  /****************************************************************************************
  * ..................................... SidNav at small screens......................
  ****************************************************************************************/
  ngAfterContentInit(): void {
    const flags = RendererStyleFlags2.DashCase | RendererStyleFlags2.Important;
    this.MediaSubscription = this.mediaObserver.asObservable().subscribe(
      (response: MediaChange[]) => {
        if (response.some(x => x.mqAlias === 'lt-sm')) {
          this.SideNavToggleButtonOnSmallScreen.nativeElement.style.display = "flex";
          this.pinButton.nativeElement.style.display = "none";
          this.FullscreenButton.nativeElement.style.display = "none";

          this.SideNav_mode = "over";
          this.hasBackDrop = true;
          this.SideNav_openingStatus = false
        } else {
          this.FullscreenButton.nativeElement.style.display = "flex";

          this.pinButton.nativeElement.style.display = "flex";
          this.SideNavToggleButtonOnSmallScreen.nativeElement.style.display = "none";
          this.SideNav_mode = "side";
          this.hasBackDrop = false;
          this.SideNav_openingStatus = true;

        };
      });
  }
  ngOnDestroy(): void {
    this.MediaSubscription.unsubscribe();
  }

  getRouterState(DashBoardOutlet: RouterOutlet) {
    return DashBoardOutlet.isActivated ? DashBoardOutlet.activatedRoute.snapshot.url[0].path : "none";
  }

  OpenExpAndCloseAll(index: number) {
    for (let i = 0; i < this.SideNavItems.length; i++) {
      if (i === index) {
        if (this.SideNavItems[i].expanded == true)
          this.SideNavItems[i].expanded = false;
        else this.SideNavItems[i].expanded = true;
      }
      else {
        this.SideNavItems[i].expanded = false

      };
    }
  }

  agGridTableDirectionToggle() {
    this.agGridTable_dir = this.agGridTableDirection.value;
    localStorage.setItem(this.Constants.Table_direction, this.agGridTable_dir);
    this.LightDarkThemeConverter.ChangeAgGridTable_dir(this.agGridTable_dir);
  }

  TableTheme(colorMode: string) {
    this.LightDarkThemeConverter.ChangeTableTheme(colorMode);
    localStorage.setItem(this.Constants.Table_Color_mode, colorMode);
  }
}
