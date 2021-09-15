using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Utilities
{
    public class Constants
    {
        //ActionNames
        public string SendConfirmationAgain = "SendConfirmationAgain";

        //Error status
        public string NullUser_statuCode = "NullUser";
        public string EmailConfirmation_StatusCode = "EmailConfirmation";
        public string WrongPassword_StatusCode = "EmailConfirmation";
        public string NullTenant_statuCode = "NullTenant";
        public string NullOwner_statuCode = "NullOwner";
        public string ResultStatus_statuCode = "RegisterResult";
        public string ModelState_statuCode = "ModelState";
        public string EmailConfirmResult_statuCode = "EmailConfirmResult";

        //error Messages
        public string NullUser_ErrorMessage = "We can't find a user with this email. Check your email and try again";
        public string NullTenant_ErrorMessage = "There is no account registered by this mail";
        public string NullOwner_ErrorMessage = "There is no account registered by this mail";
        public string Emailconfirmation_ErrorMessage = "You need to confirm your email.";
        public string WrongPassword_ErrorMessage = "Wrong Password";

        //Email Constants
        public string ConfirmationEmail_Subject = "Please confirm your email";
        public string ConfirmationEmail_Body(string emailbody)
        {
            return $"Please confirm your account by <a href='{emailbody}'>clicking here</a>.";
        }
    }
}
