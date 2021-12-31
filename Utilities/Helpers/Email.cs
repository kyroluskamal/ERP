using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ERP.Utilities.Helpers
{
    public class Email : ValidationAttribute
    {
        public Email() { }

        public override bool IsValid(object value)
        {
            var reg = @"^[^\s@]+@[^\s@]+\.[^\s@]+$";
            Regex regex = new Regex(reg);
            return value == null ? true : regex.IsMatch(value.ToString());
            //if (!regex.IsMatch(value.ToString()))
            //{
            //    ErrorMessage = "NOT_VALID_PHONE_NUMBER";
            //    return false;
            //}
            //return true;
        }

    }
}
