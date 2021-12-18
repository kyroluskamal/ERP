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
  public static Client_Loggout: string = "/api/Identity/LoggOut";

  //APIURLS for Items
  public static ItemMainCategory_GetAll_API = "/api/items/allcategories";
  public static ItemMainCategory_AddMainCat_API = "/api/items/AddMainCategory";
  public static ItemMainCategory_UPDATE_MainCat_API = "/api/items/UpdateItemMainCategory";
  public static ItemMainCategory_DELETE_MainCat_API = "/api/items/DelteItemMainCat";

  public static Item_Sub_Category_GetAll_API = "/api/items/GetItemsAllSubCategories";
  public static Item_Sub_Category_Add_API = "/api/items/AddSubCategory";
  public static Item_Sub_Category_Update_API = "/api/items/UpdateItemSubCategory";
  public static Item_Sub_Category_Delete_API = "/api/items/DelteItemSubCat";

  public static Item_Unit_Delete_API = "/api/items/DelteItemUnit";
  public static Item_Unit_Add_API = "/api/items/AddItemUnit";
  public static Item_Unit_Update_API = "/api/items/Update_Item_Unit";
  public static Item_Unit_GetAll_API = "/api/items/AllItemUnits";

  public static Item_Brand_Delete_API = "/api/items/DeleteBrand";
  public static Item_Brand_Add_API = "/api/items/AddNewBrand";
  public static Item_Brand_Update_API = "/api/items/UpdateBrand";
  public static Item_Brand_GetAll_API = "/api/items/GetAllBrands";

  //APIURLS for Inventories
  public static Inventories_GetAll_API = "/api/Inventories/AllInventories";
  public static Inventories_Add_API = "/api/Inventories/AddWarehouse";
  public static Inventories_Delete_API = "/api/Inventories/DeleteWarehouse";
  public static Inventories_Update_API = "/api/Inventories/Update_Warehouse";

  public static InventoryAddress_Add_API = "/api/Inventories/AddAddress";
  public static InventoryAddress_GET_API = "/api/Inventories/GetAllAddresses";
  public static InventoryAddress_DELETE_API = "/api/Inventories/DeleteAddress";
  public static InventoryAddress_UPDATE_API = "/api/Inventories/UpdateAddress";
  //APIURLS for Suppliers
  public static Suppliers_GetAll_API = "/api/Suppliers/AllSuppliers";

  //Client URLs
  public static Client_EmailConfirmationUrl: string = "client/emailconfirmation";
  public static Owner_EmailConfirmationUrl: string = "owners/emailconfirmation";
  public static Owner_PasswordResetURL: string = "Owner/passwordReset";
  public static Client_PasswordResetURL: string = "Client/passwordReset";
  public static Client_MainDomainAccountURL: string = "account";
  public static Client_Dashboard: string = "Dashboard";

  //................................................................................ClientAppUrls
  public static App_login = "login";
  public static App_main = "app";
  public static App_register = "register";
  //for Items
  public static App_Items = "items";
  public static App_AddNewItem = "AddNewItem";
  //for Item Categories
  public static App_ItemMainCategories = "itemsCategories";
  //for Item Units
  public static App_ItemUnits = "ItemUnits";
  //for item brands
  public static App_ItemBrands = "ItemBrands";
  //for Warehouses
  public static App_Warehouses = "Warehouses";
  public static App_AddNewWarehouse = "AddNewWarehouse";

}
