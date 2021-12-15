using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ERP.Utilities.Helpers
{
    public class PhoneNumber : ValidationAttribute
    {
        public PhoneNumber(){}

        public override bool IsValid(object value)
        {
            var reg = @"^(\+\s?)?((?<!\+.*)\(\+?\d+([\s\-\.]?\d+)?\)|\d+)([\s\-\.]?(\(\d+([\s\-\.]?\d+)?\)|\d+))*(\s?(x|ext\.?)\s?\d+)?$";
            Regex regex = new Regex(reg);

            return value == null ? true: regex.IsMatch(value.ToString());
        }
        
    }
}