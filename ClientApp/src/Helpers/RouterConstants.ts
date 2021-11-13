export abstract class RouterConstants {

  //API URLS for Identity
  public static ClientLoginMainDomain_APIurl: string = "/api/Identity/loginMainDomain";
  public static OwnerLogin_APIurl: string = "/api/Owners/Account/OwnerLogin";
  public static ClientRegister_APIurl: string = "/api/Identity/";
  public static OwnerRegister_APIurl: string = "/api/Owners/Account";
  public static Client_EmailConfirmationUrl_APIURL: string = "/api/Identity/EmailConfirmation";
  public static Client_ResendEmailConfirmation_APIURL: string = "/api/Identity/SendConfirmationAgain";
  public static Owner_EmailConfirmationUrl_APIURL: string = "/api/Owners/Account/EmailConfirmation";
  public static Owner_ResendEmailConfirmation_APIURL: string = "/api/Owners/Account/SendConfirmationAgain";
  public static Owner_ForgetPassword_APIURL: string = "/api/Owners/Account/ForgetPassword";
  public static Client_ForgetPassword_APIURL: string = "/api/Identity/ForgetPassword";
  public static Owner_ResetPassword_APIURL: string = "/api/Owners/Account/ResetPassword";
  public static Client_ResetPassword_APIURL: string = "/api/Identity/ResetPassword";
  public static Client_SocialLogins_APIURL: string = "/api/Identity/SoicalLogin";
  public static IsTenantFound_APIURL: string = "/api/Identity/IsTenantFound";

  //APIURLS for Items
  public static ItemMainCategory_GetAll_API = "/api/items/allcategories";
  public static ItemMainCategory_AddMainCat_API = "/api/items/AddMainGategory";
  public static ItemMainCategory_UPDATE_MainCat_API = "/api/items/UpdateItemMainCategory";
  public static ItemMainCategory_DELETE_MainCat_API = "/api/items/DelteItemMainCat";

  //Client URLs
  public static Client_EmailConfirmationUrl: string = "client/emailconfirmation";
  public static Owner_EmailConfirmationUrl: string = "owners/emailconfirmation";
  public static Owner_PasswordResetURL: string = "Owner/passwordReset";
  public static Client_PasswordResetURL: string = "Client/passwordReset";
  public static Client_MainDomainAccountURL: string = "account";
  public static Client_Dashboard: string = "Dashboard";

  //ClientAppUrls
  public static App_login = "login";
  public static App_main = "app";
  public static App_register = "register";
  public static App_Items = "items";
  public static App_ItemMainCategories = "itemsCategories";

}
