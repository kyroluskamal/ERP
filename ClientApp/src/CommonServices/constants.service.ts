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
}
