namespace ERP.Utilities
{
    public class Constants
    {
        //RoleNames
        public string SuperAdmin_Role = "SuperAdmin";
        public string Admin_Role = "Admin";
        public string Moderator_Role = "Moderator";
        public string Employee_Role = "Employee";
        public string CustomerService_Role = "CustomerService";
        public string Client_Role = "Client";

        //ActionNames
        public string SendConfirmationAgain = "SendConfirmationAgain";

        //Error status
        public string NullUser_statuCode = "NullUser";
        public string EmailConfirmation_StatusCode = "EmailConfirmation";
        public string WrongPassword_StatusCode = "WrongPassword";
        public string NullTenant_statuCode = "NullTenant";
        public string NullOwner_statuCode = "NullOwner";
        public string ResultStatus_statuCode = "RegisterResult";
        public string ModelState_statuCode = "ModelState";
        public string EmailConfirmResult_statuCode = "EmailConfirmResult";
        public string ResetPassword_statuCode = "ResetPassword";
        public string Email_Is_Confirmed_statuCode = "Email_Confirmed";
        public string RolenameAddtion_statuCode = "AddingRoleName";
        public string Required_field = "Required_field";
        public string Can_Not_Save_To_Db = "Can_Not_Save_To_Db";


        //error Messages
        public string NullUser_ErrorMessage = "We can't find a user with this email. Check your email and try again";
        public string NullTenant_ErrorMessage = "There are no user associated with this link";
        public string NullOwner_ErrorMessage = "There is no account registered by this mail";
        public string Emailconfirmation_ErrorMessage = "You need to confirm your email.";
        public string WrongPassword_ErrorMessage = "Wrong Password";
        public string Email_Is_Confirmed_ErrorMessage = "Email is already confirmed";
        public string RolenameAddtion_ErrorMessage = "Your account is add but we can't assign role to you. Please Contact us";
        public string Required_field_ErrorMessage = "This Field is required";
        public string Can_Not_Save_To_Db_ErrorMessage = "Error: Data is not saved to database. Try again.";

        //ValidationErrorMessages

        //ModelsConstants
        public enum IsClientOrStaffOrBoth { Client_COC = 0, Employee_COC = 1, both = 2 }
        public enum ClientType { Individual = 0, BusinessType = 1 }
        public int Male = 1;
        public int Female = 0;
        public int InvoicingMethod_Email = 0;
        public int InvoicingMethod_Print = 1;
        public enum Shift_Type { standardType = 1, AdvancedType = 0 }
        public enum IsActive { No = 0, Yes = 1 }
        public enum HasEstimates { No = 0, Yes = 1 }
        public enum HasCategory { No = 0, Yes = 1 }
        public enum HasCustomFields { No = 0, Yes = 1 }
        public enum HideField { No = 0, Yes = 1 }
        public enum EnableAutocomplete { No = 0, Yes = 1 }
        public enum HasChoices { No = 0, Yes = 1 }
        public enum EnableQuickSearch { No = 0, Yes = 1 }
        public enum HasMinAndMaxNumber { No = 0, Yes = 1 }
        public enum HasMinAndMaxDate { No = 0, Yes = 1 }
        public enum AddressType { permenant = 0, Present = 1 }
        public enum Status_OpenedOrClosed { closed = 0, opened = 1 }
        public enum IsMainInventory { No = 0, Yes = 1 }
        public enum HasExpire { No = 0, Yes = 1 }
        public enum HasDescription { No = 0, Yes = 1 }
        public enum HasSpecialOffer { No = 0, Yes = 1 }
        public enum IsOnline { No = 0, Yes = 1 }
        public enum IsEndorsed { No = 0, Yes = 1 }
        public enum HasDeposits { No = 0, Yes = 1 }
        public enum HasSubscription { No = 0, Yes = 1 }
        public enum HasShippingDetails { No = 0, Yes = 1 }


        public enum ServiceOrItem { service = 0, Item = 1 }

        public enum TaxType { Inclusive = 0, Exclusive = 1 }

        public enum DiscountType { Percent = 0, Value_Type = 1 }
        public enum DepositsType { Percent = 0, Value_Type = 1 }
        public enum HasWholeSalePrice { Percent = 0, Value_Type = 1 }
        public enum HasRetailPrice { Percent = 0, Value_Type = 1 }

        public enum IsRequired { Required = 1, NotRequired = 0, NotApplicable = -1 }
        public enum ShowingInInvoiceOptions { ShowFirstAddress = 1, DontShow = 0, ShowSecondAddress = 2 }
        public enum EnableSecondryShift { No = 0, Yes = 1 }
        public enum IsNeedPermission { No = 0, Yes = 1 }
        public enum HasNotes { No = 0, Yes = 1 }
        public enum IsApproved { No = 0, Yes = 1 }
        public enum IsCostCentersShared { No = 0, Yes = 1 }
        public enum IsClientShared { No = 0, Yes = 1 }
        public enum IsProducShared { No = 0, Yes = 1 }
        public enum IsSupplierShared { No = 0, Yes = 1 }
        public enum SpcifyAccountbranches { No = 0, Yes = 1 }
        public enum CanViewProfile { No = 0, Yes = 1 }
        public enum CanEditProfile { No = 0, Yes = 1 }
        public enum CanViewNotesOrAttachments { No = 0, Yes = 1 }
        public enum CanViewAndPayInvoices { No = 0, Yes = 1 }
        public enum CanViewAndApproveEstimates { No = 0, Yes = 1 }
        public enum CanViewWorkOrders { No = 0, Yes = 1 }
        public enum CanViewAppoinments { No = 0, Yes = 1 }
        public enum DiableBooking { No = 0, Yes = 1 }
        public enum DisableBookingCancelation { No = 0, Yes = 1 }
        public enum DisableClientOnlineAccess { No = 0, Yes = 1 }
        public enum HasAttachments { No = 0, Yes = 1 }
        public enum IsForClient { No = 0, Yes = 1 }
        public enum HashShippingFees { No = 0, Yes = 1 }
        public enum IsForCategory { No = 0, Yes = 1 }
        public enum IsForSubCatategory { No = 0, Yes = 1 }
        public enum HasPrefix { No = 0, Yes = 1 }
        public enum HasPymentTerms { No = 0, Yes = 1 }
        public enum HasDiscount { No = 0, Yes = 1 }
        public enum IsRecieved { No = 0, Yes = 1 }
        public enum IsPartiallyPaid { No = 0, Yes = 1 }
        public enum IsAlreadyPaid { No = 0, Yes = 1 }
        public enum IsSharedWithClient { No = 0, Yes = 1 }
        public enum IsRepeated { No = 0, Yes = 1 }
        public enum IsAssignedToStaff { No = 0, Yes = 1 }
        public enum IsOnlyOneService { No = 0, Yes = 1 }
        public enum DisplayDateFromAndTo { No = 0, Yes = 1 }
        public enum EnableAutomaticPayment { No = 0, Yes = 1 }
        public enum SendViaEmail { No = 0, Yes = 1 }
        public enum HasTerms { No = 0, Yes = 1 }
        public enum DetuctionOrEarning { No = 0, Yes = 1 }
        public enum AmountOrFormula { No = 0, Yes = 1 }
        public enum IsPaidFromPaySlip { No = 0, Yes = 1 }
        public enum IsPaid { No = 0, Yes = 1 }
        public enum IsConfirmed { No = 0, Yes = 1 }
        public enum Disable_Edit_PerItem_InInvoice { No = 0, Yes = 1 }
        public enum DisableEstimateModule { No = 0, Yes = 1 }
        public enum IsManualInvoiceNumber { No = 0, Yes = 1 }
        public enum EnableInvoiceManualStatus { No = 0, Yes = 1 }
        public enum EnableEstimateManualStatus { No = 0, Yes = 1 }
        public enum EnableMaximumDiscount { No = 0, Yes = 1 }
        public enum AutoPayFromBalance { No = 0, Yes = 1 }

        public enum IsUnique { Unique = 1, NotUnique = 0, NotApplicable = -1 }

        public enum MaxAndMinNumberType { Digit = 0, Value = 1 }
        public enum SentToClientMethod { Mail = 0, Print = 1 }
        public enum PackageType { Membership = 0, CreditCharge = 1 }
        public enum BookingPaymentSettings { Disabled = 0, Enabled = 1, Optional = 2 }
        public enum Subscription_GenerateEvery { Days = 0, Weeks = 1, Monthes = 2, Years = 3 }
        public enum PeriodType { Weekly = 0, Monthly = 1, Yearly = 2 }
        public enum PeriodOfInstallment { Monthly = 0, Quarterly = 1, Yearly = 2 }
        public enum CommissionPeriod { Monthly = 0, Quarterly = 1, Yearly = 2 }
        public enum EstimateFor { Services = 0, Items = 1 }
        public enum PermissionType { Vacation = 0, Delay = 1 }
        public enum DurationOrEndDate { Duration = 0, EndDate = 1 }
        public enum MonthOrYear { Month = 0, Year = 1 }
        public enum CalculationType
        {
            Fully_Paid_Invoices = 0,
            Partially_Paid_Invoices = 1
        }
        public enum ForCatOrItemOrService
        {
            Itemcat = 0, Item = 1, Service_Cat = 2, Service = 3
        }
        public enum TargetType
        {
            Revenue = 0, Volume = 1
        }


        public enum FieldsLayoutSize
        {
            X_small = 0,
            small = 1,
            Medium = 2,
            Large = 3,
            X_large = 4
        }
        public enum PayrollFrequency
        {
            Annually = 0,
            Bi_Weekly = 1,
            Monthly = 2,
            Quarterly = 3,
            Semi_annual = 4,
            Weekly = 5
        }
        public enum NumberingStyle
        {
            Lowercase_HexNumbers = 0,
            Lppercase_HexNumbers = 1,
            Lowercase_Letters = 2,
            Uppercase_Letters = 3,
            Lowercase_Letters_followed_by_NumericDigits = 4,
            Uppercase_Letters_followed_by_NumericDigits = 5,
        }
        public enum PaymentStatus
        {
            Incomplete = 0,
            Completed = 1,
            Pending = 2,
            Failed = 3
        }
        public enum NumberingPrefixMode
        {
            Continue_onLastNumber = 0,
            Create_SeparateSerial_For_Each_prefix = 1,
            Start_From_Beginning = 3
        }
        public enum AttendanceStatus { present = 0, onleave = 1, Absense = 2 }
        //Email Constants
        public string ConfirmationEmail_Subject = "Please confirm your email";
        public string ResetPassword_Subject = "Password Reset";
        public string ConfirmationEmail_Body(string emailbody)
        {
            return $"Please confirm your account by <a href='{emailbody}'>clicking here</a>.";
        }
        public string ResetEmail_Body(string emailbody)
        {
            return $"To reset your password <a href='{emailbody}'>clicking here</a>.";
        }
    }
}
