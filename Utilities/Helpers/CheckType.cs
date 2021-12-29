using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;

namespace ERP.Utilities.Helpers
{
    public class CheckType : ValidationAttribute
    {
        public string[] T { get; set; }
        public CheckType(string[] type) {
            T = type;
        }

        public override bool IsValid(object value)
        {
            var type = Convert.GetTypeCode(value);
            Debug.WriteLine(T.Contains(type.ToString()));
            return value == null ? true : T.Contains(type.ToString());
        }

    }
}
