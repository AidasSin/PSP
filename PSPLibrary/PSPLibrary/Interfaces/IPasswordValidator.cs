using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSPLibrary.Interfaces
{
    public interface IPasswordValidator
    {
        public bool CheckPassword(string password);
        public bool CheckPasswordLength(string password);
        public bool CheckPasswordForUppercaseSymbols(string password);
        public bool CheckPasswordForSpecialSymbols(string password);

    }
}
