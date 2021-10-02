using PSPLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSPLibrary
{
    public class PhoneValidator : IPhoneValidator
    {
        NumberValidationRule LTUrule = new NumberValidationRule
        {
            length = 12,
            prefix = "+370"
        };

        public bool CheckNumber(string number)
        {
            if (number.StartsWith("8"))
                number = ChangeNumberPrefix(number);

            if (CheckNumberForNonNumericSymbols(number) &&
                CheckNumberLength(number))
                return true;
            return false;
        }

        public string ChangeNumberPrefix(string number)
        {
            var changedNumber = LTUrule.prefix + number.Substring(1, number.Length - 1);

            return changedNumber;
        }

        public bool CheckNumberLength(string number)
        {
            if (number.Length != LTUrule.length)
                return false;
            return true;
        }

        public bool CheckNumberForNonNumericSymbols(string number)
        {
            if(number.StartsWith("+"))
            {
                number = number.Split("+")[1];
            }

            foreach (char c in number)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }
        public NumberValidationRule AddNewNumberRule(int length, string prefix)
        {
            return new NumberValidationRule 
            { 
                length = length, 
                prefix = prefix
            };
        }
    }
}
