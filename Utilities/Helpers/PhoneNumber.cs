using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ERP.Utilities.Helpers
{
    public class PhoneNumber : ValidationAttribute
    {
        public PhoneNumber(){}

        public override bool IsValid(object value)
        {
            var reg = @"\+?(\(?[0-9]+\)?)?[0-9]+\s?((x|ext)[0-9]+)?$";
            Regex regex = new Regex(reg);
            return value == null ? true: regex.IsMatch(value.ToString());
        }
        
    }
}