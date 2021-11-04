using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        //error Messages
        public string NullUser_ErrorMessage = "We can't find a user with this email. Check your email and try again";
        public string NullTenant_ErrorMessage = "There is no account registered by this mail";
        public string NullOwner_ErrorMessage = "There is no account registered by this mail";
        public string Emailconfirmation_ErrorMessage = "You need to confirm your email.";
        public string WrongPassword_ErrorMessage = "Wrong Password";
        public string Email_Is_Confirmed_ErrorMessage = "Email is already confirmed";
        public string RolenameAddtion_ErrorMessage = "Your account is add but we can't assign role to you. Please Contact us";

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
        public enum IsMainInventory { closed = 0, opened = 1 }
        public enum HasExpire { closed = 0, opened = 1 }
        public enum HasDescription { closed = 0, opened = 1 }
        public enum HasSpecialOffer { closed = 0, opened = 1 }
        public enum IsOnline { closed = 0, opened = 1 }

        public enum TaxType {Inclusive = 0, Exclusive = 1}

        public enum DiscountType {Percent = 0, Value_Type = 1}
        public enum HasWholeSalePrice { Percent = 0, Value_Type = 1}
        public enum HasRetailPrice { Percent = 0, Value_Type = 1}

        public enum IsRequired {Required = 1, NotRequired = 0, NotApplicable = -1}
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

        public enum IsUnique {Unique = 1, NotUnique = 0, NotApplicable = -1}

        public enum MaxAndMinNumberType { Digit = 0, Value = 1 }
        public enum PermissionType { Vacation = 0, Delay = 1 }

        public enum FieldsLayoutSize
        {
            X_small = 0,
            small = 1,
            Medium = 2,
            Large = 3,
            X_large = 4,
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
