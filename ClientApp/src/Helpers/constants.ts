export abstract class Constants {
  static Owner: string = "Owner";
  static Client: string = "Client";
  static email: string = "email";
  static token: string = "token";

  //API URLS
  static ClientLoginMainDomain_APIurl: string = "/api/Identity/loginMainDomain";
  static OwnerLogin_APIurl: string = "/api/Owners/Account/OwnerLogin";
  static ClientRegister_APIurl: string = "/api/Identity/";
  static OwnerRegister_APIurl: string = "/api/Owners/Account";
  static Client_EmailConfirmationUrl_APIURL: string = "/api/Identity/EmailConfirmation";
  static Client_ResendEmailConfirmation_APIURL: string = "/api/Identity/SendConfirmationAgain";
  static Owner_EmailConfirmationUrl_APIURL: string = "/api/Owners/Account/EmailConfirmation";
  static Owner_ResendEmailConfirmation_APIURL: string = "/api/Owners/Account/SendConfirmationAgain";

  //Client URLs
  static Client_EmailConfirmationUrl: string = "client/emailconfirmation";
  static Owner_EmailConfirmationUrl: string = "owners/emailconfirmation";
}
