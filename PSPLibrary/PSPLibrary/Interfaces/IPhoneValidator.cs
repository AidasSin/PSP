using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSPLibrary.Interfaces
{
    public interface IPhoneValidator
    {
        public bool CheckNumber(string number);
        public bool CheckNumberLength(string number);
        public string ChangeNumberPrefix(string number);
        public bool CheckNumberForNonNumericSymbols(string number);
        public NumberValidationRule AddNewNumberRule(int length, string prefix);

    }
}
