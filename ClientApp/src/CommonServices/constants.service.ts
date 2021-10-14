import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ConstantsService {

  constructor() { }
  isRightToLeft(lang: any) {
    switch (lang) {
      case 'ar': return true;
      case 'arc': return true;
      case 'dv': return true;
      case 'fa': return true;
      case 'ha': return true;
      case 'he': return true;
      case 'khw': return true;
      case 'ks': return true;
      case 'ku': return true;
      case 'ps': return true;
      case 'ur': return true;
      case 'yi': return true;
      default: return false;
    }
  }
  CurrentLang = localStorage.getItem("lang");
  Owners: string = "owners";
  Owner: string = "Owner";
  Client: string = "Client";
  email: string = "email";
  token: string = "token";
  RememberMe: string = "RememberMe";
  ClientRememberMe: string = "CleintRememberMe";
  OwnerRememberMe: string = "OwnerRememberMe";
  lang: string = "lang";

  //Notifications Messages
  LoggedInSuccessfully: string = "LoggedInSuccessfully";
  EmilConfirmationResnding = "EmilConfirmationResnding";
  EmilConfirmationResnding_success = "EmilConfirmationResnding_success";
  PasswordResetEmail_success = "PasswordResetEmail_success";
  EmilConfirmationResnding_Error = "EmilConfirmationResnding_Error"
  PasswordResetEmail_Error = "PasswordResetEmail_Error;"
  ResetPassword_Error = "ResetPassword_Error";
  ResetPassword_Success = "ResetPassword_Success";
  BrowserDontSupportFullscreen = "BrowserDon'tSupportFullscreen";
  SuccessfulRegistration = "SuccessfulRegistration";

  //Tooltip translation
  CloseSidebar = "Close sidebar";
  FixSidebar = "Fix sidebar";
  FullscreenMode_enable = "FullscreenMode_enable";
  FullscreenMode_exit = "FullscreenMode_exit";
  ChooseYourLang = "ChooseYourLang";
  Dark = "Dark";
  Ligh = "Light";
  Layout_LTR = "Layout_LTR";
  Layout_RTL = "Layout_RTL";
  //Interceptor Notigication translations

  PleaseCorrectErrors = "PleaseCorrectErrors";
  Something_nexpected_went_wrong = "Something unexpected went wrong"

  PleaseCorrectErrors_En = "Please correct the errors and try again";
  Something_nexpected_went_wrong_EN = "Something unexpected went wrong";

  PleaseCorrectErrors_AR_translation = "من فضلك صحح الاخطاء وحاول مرة اخرى.";
  Something_nexpected_went_wrong_Arabic = "حدث خطأ غير متوقع";
  //Static Functions
  ClientUrl(url: string): string {
    return "https://" + window.location.host + "/" + url;
  }

  //RoleNames
  Admin_Role = "Admin";

  //Guards Error Messages
  UnAuthorizedAdmin = "UnAuthorizedAdmin";
  NotLoggedInUser = "NotLoggedInUser";

  //Animations Name
  FadeUp = "FadeUp"; FadeUp_Class = "animated fadeInUp";
  BounceUp = "BounceUp"; BounceUp_Class = "animate__animated animate__bounce";


  //CSS Classes
  CSS_ToolBar = "ToolBar";
  CSS_mat_elevation_z9 = "mat-elevation-z9";
  CSS_btn = "btn";
  CSS_btn_primary = "btn-primary";
  CSS_btn_info = "btn-info";
  CSS_btn_success = "btn-success";
  CSS_btn_warning = "btn-warning";
  CSS_btn_danger = "btn-danger";
  CSS_btn_neutral = "btn-neutral";
  CSS_btn_black = "btn-black";
  CSS_ButtonArabicFont = "ButtonArabicFont";
  CSS_langSelectorMaidDomainStyle = "langSelectorMaidDomainStyle";
  CSS_langSelectionSize = "langSelectionSize";
  CSS_loginButton = "loginButton";
  CSS_logo = "logo";
  CSS_Background_transparent = "bg-transparent";
  CSS_LelezarFont = "LelezarFont";
  CSS_Calibri_font = "Calibri-font";
  CSS_max_height_100vh = "max-height-100vh";
  CSS_max_width_100vh = "max-width-100vh";
  CSS_min_width_100vh = "min-width-100vh";
  CSS_max_width_100 = "max-width-100";
  CSS_ScheherazadeNew_Bold = "ScheherazadeNew-Bold";
  CSS_ScheherazadeNew_Regular = "ScheherazadeNew-Regular";
  CSS_bg_white = "bg-white";
  CSS_alert_danger = "alert-danger";
  CSS_alert_warning = "alert-warning";
  CSS_alert_link = "alert-link";
  CSS_alert_info = "alert-info";
  CSS_alert_success = "alert-success";
  CSS_alert_dismissable = "alert-dismissable";
  CSS_alert = "alert";
  CSS_Error_Notification = "Error-Notification";
  CSS_Success_Notification = "Success-Notification";
  CSS_homeLink = "homeLink";
  CSS_marginTop_5 = "marginTop-5";
  CSS_text_danger = "text-danger";
  CSS_text_white = "text-white";
  CSS_text_primary = "text-primary";
  CSS_text_warning = "text-warning";
  CSS_text_success = "text-success";
  CSS_text_info = "text-info";
  CSS_justify_Content_Center = "justify-Content-Center";
  CSS_buttonLink = "buttonLink";
  CSS_container = "container";
  CSS_password = "password";
  CSS_closeIcon = "closeIcon";
  CSS_valid_green = "";
  CSS_subdomain = "subdomain";
  CSS_dialog_header = "dialog-header";
  CSS_bg_grey = "bg-grey";
  CSS_pointerCursor = "pointerCursor";
  CSS_border_white = "b-white";
  CSS_Width100 = "Width100";
  CSS_mat_elevation_z4 = "mat-elevation-z4";

  CSS_SideNav_HalfClosed = "SideNav-HalfClosed";
  CSS_SideNav_FullOpened = "SideNav-FullOpened";
  CSS_displayNone = "displayNone";
  CSS_display_inline_block = "display-inline-block";
  CSS_SideNav_fullyClosed = "SideNav-fullyClosed";
  CSS_sidenav_content_nonPinned_LTR = "mat-sidenav-content-nonPinned-LTR";
  CSS_sidenav_content_nonPinned_RTL = "mat-sidenav-content-nonPinned-RTL";
  CSS_sidenav_content_pin_LTR = "mat-sidenav-content-pin-LTR";
  CSS_sidenav_content_pin_RTL = "mat-sidenav-content-pin-RTL";
  CSS_Openned_pin = "Openned-pin";
  CSS_Dashboard_ToolTip = "Dashboard-ToolTip";
  CSS_text_center = "text-center";
  CSS_Dashboard_Sidenav_CompmanyName = "Dashboard-Sidenav-CompmanyName";
  CSS_userIconImage = "userIconImage";
  CSS_padding_10 = "padding-10";
  CSS_light_for_others = "light-for-others";
  CSS_dark_for_others = "dark-for-others";
  CSS_Dark_for_body = "dark-for-Body";
  CSS_light_for_body = "light-For_body";
  CSS_smallCloseIcone = "smallCloseIcone";

  CSS_blue_bg = "blue-bg";
  CSS_amber_bg = "amber-bg";
  CSS_cyan_bg = "cyan-bg";
  CSS_deep_organge_bg = "deep_organge-bg";
  CSS_deep_purple_bg = "deep_purple-bg";
  CSS_green_bg = "green-bg";
  CSS_organge_bg = "organge-bg";
  CSS_pink_bg = "pink-bg";
  CSS_purple_bg = "purple-bg";
  CSS_red_bg = "red-bg";
  CSS_teal_bg = "teal-bg";

  CSS_blue = "blue";
  CSS_amber = "amber";
  CSS_cyan = "cyan";
  CSS_deep_organge = "deep_organge";
  CSS_deep_purple = "deep_purple";
  CSS_green = "green";
  CSS_organge = "organge";
  CSS_pink = "pink";
  CSS_purple = "purple";
  CSS_red = "red";
  CSS_teal = "teal";

  CSS_dark_color = "dark-color";
  CSS_light_color = "light-color"
  //Local Stoarage
  FixedSidnav = "FixedSidNav";
  ToolbarThemeClass = "ToolbarThemeClass";
  BodyThemeClass = "BodyThemeClass";
  SideNavThemeClass = "SideNavThemeClass";
  ThemeAppearence = "ThemeAppearence";
  SidebarAppeareance = "SidebarAppeareance";
  BodyAppeareance = "BodyAppeareance";
  ToolbarAppeareance = "ToolbarAppeareance";
  dir = "dir";
  ChoosenThemeColors = "ChoosenThemeColors";
}
