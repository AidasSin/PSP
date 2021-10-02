using Microsoft.Extensions.Configuration;
using PSPLibrary.Interfaces;
using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSPLibrary
{
    public class PasswordValidator : IPasswordValidator
    {
       // private readonly IConfiguration _configuration;
        private readonly int _minimumPasswordLength = 8;


        public bool CheckPassword(string password)
        {
            if (CheckPasswordLength(password) && 
                CheckPasswordForUppercaseSymbols(password) &&
                CheckPasswordForSpecialSymbols(password))
                return true;
            else
                return false;
        }

        public bool CheckPasswordLength(string password)
        {
            if (password.Length >= _minimumPasswordLength)
                return true;
            else
                return false;
        }
        public bool CheckPasswordForUppercaseSymbols(string password)
        {
            if (password.Any(char.IsUpper))
                return true;
            else
                return false;
        }
        public bool CheckPasswordForSpecialSymbols(string password)
        {
            bool doesPasswordContainSymbols = true;
            var passwordSpecialSymbols = ConfigurationManager.AppSettings.Get("passwordSpecialSymbols");
            var specialSymbols = passwordSpecialSymbols.Split(',');

            for(int i = 0; i < passwordSpecialSymbols.Length; i++)
            {
                if (!password.Contains(specialSymbols[i]))
                    doesPasswordContainSymbols = false;
            }
            return doesPasswordContainSymbols;
        }
    }
}
