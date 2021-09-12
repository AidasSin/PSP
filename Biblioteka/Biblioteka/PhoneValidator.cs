using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteka
{
    public class PhoneValidator
    {
        public bool IsPhoneNumberValid(string phoneNumber)
        {
            return false;
        }
        public string ChangeNumberPrefix(string phoneNumber)
        {
            return "+37061234567";
        }
        public ValidationRule AddValidationRule(int lenght, string prefix)
        {
            return new ValidationRule { length = 12, prefix = "+123" };
        }
    }
}
