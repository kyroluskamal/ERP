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
