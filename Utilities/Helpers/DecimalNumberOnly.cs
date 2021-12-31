using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ERP.Utilities.Helpers
{
    public class DecimalNumberOnly : ValidationAttribute
    {
        public DecimalNumberOnly() { }

        public override bool IsValid(object value)
        {
            var reg = @"[0-9]+(\.[0-9]+)?$";
            Regex regex = new Regex(reg);
            if (!regex.IsMatch(value.ToString()))
            {
                ErrorMessage = "NaN";
                return false;
            }
            return true;
        }

    }
}
