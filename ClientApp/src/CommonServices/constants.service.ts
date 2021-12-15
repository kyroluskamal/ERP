import { Injectable } from '@angular/core';

import { NotificationsService } from './NotificationService/notifications.service';
import { TranslationService } from './translation-service.service';

@Injectable({
  providedIn: 'root'
})
export class ConstantsService {

  constructor() { }

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

  /*******************************************************************************
  ............................. Treanslation Keys ................................
  ********************************************************************************/
  //Form Keys
  Main_Categories = "Main_Categories";
  Sub_Categories = "Sub_Categories";
  Add_Edit_Delete = "Add_Edit_Delete";
  Search_table = "Search table";
  loading = "loading";
  SelectOneMainCat = "Select One main category";
  MainCatName = "MainCatName";
  SubCatName = "SubCatName";
  Add = "Add";
  New = "New"
  Sub_Categories_Singular = "Sub_Categories_Singular";
  MainCat_Singular = "MainCat_Singular";
  WholeSaleUnit = "Wholesale Unit";
  Delete = "Delete";
  Name = "Name";
  RetailUnit = "Retail Unit";
  NumberInWholeSale = "Number in wholesale";
  NumberInRetailSale = "Number in Retail Sale";
  ConversionRate = "Conversion Rate";
  Unit = "Unit";
  Units = "Units"
  Brand_Name_Singular = "Brand_Name_Singular";
  Brand_Names = "Brand_Names";
  Products = "Products";
  Product = "Product";
  Add_New_Product = "Add_New_Product";
  Product_Main_Details = "Product_Main_Details";
  Has_Expiry_Date = "Has_Expiry_Date";
  Available_online = "Available_online";
  SelectDefultInventory = "SelectDefultInventory";
  ProductName = "ProductName";

  Description = "Description";
  InternalNotes = "InternalNotes";
  Item_Units = "Item_Units";
  Select_Item_Unit = "Select_Item_Unit";
  NoUnitsAdded = "NoUnitsAdded";

  Add_New_Units = "Add_New_Units";
  Search = "Search";
  Add_New_Inventory = "Add_New_Inventory";
  NoAddedInvetories = "NoAddedInvetories";
  SelectMainCategory = "SelectMainCategory";
  Select_Sub_Category = "Select_Sub_Category";
  Select_ItemBrand = "Select_ItemBrand";
  NoMainCatsAdded = "NoMainCatsAdded";
  NoSubCatsAdded = "NoSubCatsAdded";
  NoItemBrandsAdded = "NoItemBrandsAdded";

  ItemVariants_Prices_Details = "ItemVariants_Prices_Details";
  IncorrecEmail = "IncorrecEmail";

  SelectDefaultSupplier = "SelectDefaultSupplier";
  NoSupplierAdded = "NoSupplierAdded";
  Supplier_Singular = "Supplier_Singular";
  Warehouses = "Warehouses";
  Warehouse_Singular = "Warehouse_Singular";
  Notes = "Notes";
  WarehouseName = "warehousename";
  TelephoneNumber = "telephone";
  CellPhoneNumber = "mobilephone";
  Active = "Active";
  InActive = "InActive";
  Main = "Main";
  NonMain = "NonMain";
  AddedBy = "AddedBy";
  MainWarehouse = "Main warehouse";
  Edit = "Edit";
  NOT_VALID_PHONE_NUMBER = "NOT_VALID_PHONE_NUMBER";
  ItemPerPageLabal = "ItemPerPageLabal";
  FirstPage = "FirstPage";
  NextPage = "NextPage";
  PreviousPage = "PreviousPage";
  LastPage = "LastPage";
  address = "address";
  buildingNo = "buildingNo";
  flatNo = "flatNo";
  addressLine_1 = "addressLine_1";
  addressLine_2 = "addressLine_2";
  postalCode = "postalCode";
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
  DataAddtionStatus_Success = "DataAddtionStatus_Success";
  DataAddtionStatus_error = "DataAddtionStatus_Error";
  NullTenant = "NullTenant";
  Required_field_Error = "Required_field";
  Data_Deleted_ERROR_status = "Data_Deleted_ERROR";
  Data_NOTFOUND_ERROR_status = "Data_NOTFOUND_ERROR";
  Data_Deleted_success_status = "Data_Deleted_success";
  Data_SAVED_success_status = "Data_SAVE_success";
  Data_SAVED_ERROR_status = "Data_SAVE_ERROR";
  MainCatNameIsRequired = "MainCatNameIsRequired";
  Sub_CatNameIsRequired = "Sub_CatNameIsRequired";
  UnCategorized_Can_tDeleted_Or_Updated = "UnCategorized_Can'tDeleted_Or_Updated";
  Uncategorized = "Uncategorized";
  HackTrying_Error = "HackTrying_Error";
  Unique_Field_ERROR = "Unique_Field_ERROR";
  Model_state_errors = "One or more validation errors occurred.";
  RequiredMainCat_name = "Please, write the name of the category";
  Unique_SubCat_Per_MainCat_ERROR = "Unique_SubCat_Per_MainCat_ERROR";
  NotSelected_MainCat = "NotSelected_MainCat";
  MaxLengthExceeded_ERROR = "MaxLengthExceeded_ERROR";
  characters = "characters";
  Negative_Value_ERROR = "Negative_Value_ERROR";
  AntiForgery_Error = "AntiForgery_Error";
  Unauthorized_Error = "Unauthorized_Error";
  ConfermationEmail_Resend = "ConfermationEmail_Resend";
  ClickHere = "Click here";
  WelcomeBack = "WelcomeBack";
  EmailRequired = "EmailRequired";
  PasswordRequired = "PasswordRequired";
  ConfirmPasswordNoPassswordMatch = "ConfirmPasswordNoPassswordMatch";
  Delete_Default_inventory_Error = "Delete_Default_inventory_Error";
  //Tooltip translation
  CloseSidebar = "Close sidebar";
  FixSidebar = "Fix sidebar";
  FullscreenMode_enable = "FullscreenMode_enable";
  FullscreenMode_exit = "FullscreenMode_exit";
  ChooseYourLang = "ChooseYourLang";
  dark = "Dark";
  light = "Light";
  Layout_LTR = "Layout_LTR";
  Layout_RTL = "Layout_RTL";
  Table_Settings = "Table_Settings";
  Table_direction = "Table_direction";
  Table_Color_mode = "Table_Color_mode";
  Table_RTL = "Table_RTL";
  Table_LTR = "Table_LTR";

  //Interceptor Notigication translations
  PleaseCorrectErrors = "PleaseCorrectErrors";
  Something_nexpected_went_wrong = "Something unexpected went wrong"

  PleaseCorrectErrors_En = "Please correct the errors and try again";
  Something_nexpected_went_wrong_EN = "Something unexpected went wrong";

  PleaseCorrectErrors_AR = "من فضلك صحح الاخطاء وحاول مرة اخرى.";
  Something_nexpected_went_wrong_Arabic = "حدث خطأ غير متوقع";
  NullTenant_errorMessage_Ar = "لا يوجد حساب خاص بهذا الرابط.";
  NullTenant_errorMessage_En = "There are no user associated with this link";

  Data_Deleted_ERROR_Message_En = "Error: Faild to delete data from database.";
  Data_Deleted_ERROR_Message_Ar = "خطأ: فشل في حذف الباينات من قاعدة البيانات.";

  Data_NOTFOUND_ERROR_Message_EN = "Error: Data is not found in database.";
  Data_NOTFOUND_ERROR_Message_Ar = "خطا: لم يتم العثور على الباينات في قاعدة الباينات.";

  Data_Deleted_success_Message_En = "Data is deleted from databse successfully";
  Data_Deleted_success_Message_Ar = "تم حذف البيانات بنجاح";

  DataAddtionStatus_Error_Message_En = "Error: Data is not added to database. Try again.";
  DataAddtionStatus_Error_Message_Ar = "خطأ : ليم يتم اضافة البيانات في قاعدة البيانات. حاول مرة اخرى.";

  Required_field_Error_Message_Ar = "هذا الحقل مطلوب.";
  Required_field_Error_Message_En = "This field is required.";

  Data_SAVED_success_message_EN = "Data is saved successfully";
  Data_SAVED_success_message_Ar = "تم حفظ البيانات بنجاح";

  HackTrying_Error_message_EN = "You are trying to enter the subdomain manually. This is forbidden.";
  HackTrying_Error_message_Ar = "انت تحاول اداخل الدومين الفرعي يدويا. هذا غير مسموح.";

  Unique_SubCat_Per_MainCat_ERROR_Message_EN = "You can't repeat subcategory in the same main category. Add UNIQUE value.";
  Unique_SubCat_Per_MainCat_ERROR_Message_AR = "لايمكن تكرار نفس التصنيف الفرعي داخل نفس التصنيف الرئيسي. اضف قيماً فريدة.";

  NotSelected_MainCat_Message_EN = "Please, select a Main category from the Main categories table";
  NotSelected_MainCat_Message_Ar = "اختار التصنيف الرئيسي اولا من جدول التصنيفات الرئيسية"

  //ValidatioErrorMessages


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
  CSS_cursive_font_NotClass = "cursive";
  CSS_Hacen_Casablanca_font_NotClass = 'Hacen Casablanca';
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

  CSS_dark_for_Child_Component = "dark-for-Child-Component";
  CSS_Light_for_Child_Component = "Light-for-Child-Component";
  CSS_DarkRowSelection = "DarkRowSelection";
  CSS_LightRowSelection = "LightRowSelection";
  CSS_DarkTableBg = "DarkTableBg";
  CSS_LightTableBg = "LightTableBg";

  CSS_table_container = "table-container";
  CSS_table_outer_Container = "table-outer-container"
  CSS_loading_shade = "loading-shade";
  CSS_badge_dark = "badge-dark";
  CSS_badge_light = "badge-light";
  CSS_badge_info = "badge-info";
  CSS_badge_warning = "badge-warning";
  CSS_badge_danger = "badge-danger";
  CSS_badge_secondary = "badge-secondary";
  CSS_badge_primary = "badge-primary";
  CSS_badge_success = "badge-success";
  CSS_badge = "badge";
  CSS_TablefilterDiv = "TablefilterDiv";
  NoMatchedData = "NoMatchedData";
  Found = "Found";
  results = "results";
  CSS_TableSettingsMenu = "TableSettingsMenu";
  CSS_Space_evenly = 'space-evenly'
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


  //..............................................................ClientAppUrls
  public App_login = "login";
  public App_main = "app";
  public App_register = "register";

  //for items
  public App_Items = "Products";
  public App_ItemsMainCat = "Categories";
  public App_ItemsUnits = "Units";
  public App_ItemsBrands = "Brands";
  public App_AddNewItem = "Add_New_Product";

  //for inventories
  public App_Warehouses = "Warehouses";
  public App_AddNewWarehouse = "Add_new_warehouse";


  //Keyboard Keys
  public ArrowDown = "ArrowDown";
  public ArrowUp = "ArrowUp";
  public Enter = "Enter";




}
