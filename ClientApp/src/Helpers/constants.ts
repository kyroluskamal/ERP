export abstract class Constants {
  static Owners: string = "owners";
  static Owner: string = "Owner";
  static Client: string = "Client";
  static email: string = "email";
  static token: string = "token";
  static RememberMe: string = "RememberMe";
  static ClientRememberMe: string = "CleintRememberMe";
  static OwnerRememberMe: string = "OwnerRememberMe";
  static lang: string = "lang";

  //API URLS
  static ClientLoginMainDomain_APIurl: string = "/api/Identity/loginMainDomain";
  static OwnerLogin_APIurl: string = "/api/Owners/Account/OwnerLogin";
  static ClientRegister_APIurl: string = "/api/Identity/";
  static OwnerRegister_APIurl: string = "/api/Owners/Account";
  static Client_EmailConfirmationUrl_APIURL: string = "/api/Identity/EmailConfirmation";
  static Client_ResendEmailConfirmation_APIURL: string = "/api/Identity/SendConfirmationAgain";
  static Owner_EmailConfirmationUrl_APIURL: string = "/api/Owners/Account/EmailConfirmation";
  static Owner_ResendEmailConfirmation_APIURL: string = "/api/Owners/Account/SendConfirmationAgain";
  static Owner_ForgetPassword_APIURL: string = "/api/Owners/Account/ForgetPassword";
  static Client_ForgetPassword_APIURL: string = "/api/Identity/ForgetPassword";
  static Owner_ResetPassword_APIURL: string = "/api/Owners/Account/ResetPassword";
  static Client_ResetPassword_APIURL: string = "/api/Identity/ResetPassword";
  static Client_SocialLogins_APIURL: string = "/api/Identity/SoicalLogin";
  //Client URLs
  static Client_EmailConfirmationUrl: string = "client/emailconfirmation";
  static Owner_EmailConfirmationUrl: string = "owners/emailconfirmation";
  static Owner_PasswordResetURL: string = "Owner/passwordReset";
  static Client_PasswordResetURL: string = "Client/passwordReset";

  //Notifications Messages
  static LoggedInSuccessfully : string= "You have logged in successfully";
  static EmilConfirmationResnding: string = "Email confirmation resended agian";
  static EmilConfirmationResnding_success: string = "Email confirmation resended agian";
  static PasswordResetEmail_success: string = "Password Email link have been sent successfully";
  static EmilConfirmationResnding_Error: string = "Can't resend Email confirmation again. Please contact us";
  static PasswordResetEmail_Error: string = "Failed to sent password link. Please try again or contact us";
  static ResetPassword_Error: string ="Failed to reset password" ;
  static ResetPassword_Success: string = "Password reset is successful";

  //Static Functions
  static ClientUrl(url: string) : string{
    return "https://" + window.location.host + "/" + url;
  }

  //RoleNames
  static Admin_Role = "Admin";

  //Guards Error Messages
  static UnAuthorizedAdmin = "Your are not admin to access this area";
  static NotLoggedInUser = "You are not logged in. Please login to access this page";
}
