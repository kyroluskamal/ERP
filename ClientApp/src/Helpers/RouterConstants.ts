export abstract class RouterConstants {

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
  static Client_MainDomainAccountURL: string = "account";
  static Client_Dashboard: string = "Dashboard";

}
