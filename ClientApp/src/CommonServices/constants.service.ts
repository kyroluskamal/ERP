import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ConstantsService {

  constructor() { }
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
  LoggedInSuccessfully: string = "You have logged in successfully";
  EmilConfirmationResnding: string = "Email confirmation resended agian";
  EmilConfirmationResnding_success: string = "Email confirmation resended agian";
  PasswordResetEmail_success: string = "Password Email link have been sent successfully";
  EmilConfirmationResnding_Error: string = "Can't resend Email confirmation again. Please contact us";
  PasswordResetEmail_Error: string = "Failed to sent password link. Please try again or contact us";
  ResetPassword_Error: string = "Failed to reset password";
  ResetPassword_Success: string = "Password reset is successful";

  //Static Functions
  ClientUrl(url: string): string {
    return "https://" + window.location.host + "/" + url;
  }

  //RoleNames
  Admin_Role = "Admin";

  //Guards Error Messages
  UnAuthorizedAdmin = "Your are not admin to access this area";
  NotLoggedInUser = "You are not logged in. Please login to access this page";

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
  CSS_sidenav_content_initial = "mat-sidenav-content-initial";
  CSS_sidenav_content_pin = "mat-sidenav-content-pin";
  CSS_Openned_pin = "Openned-pin";
  CSS_Dashboard_ToolTip = "Dashboard-ToolTip";
  CSS_text_center = "text-center";
  CSS_Dashboard_Sidenav_CompmanyName = "Dashboard-Sidenav-CompmanyName";
  CSS_userIconImage = "userIconImage";

  //Local Stoarage
  FixedSidnav = "FixedSidNav";
}
