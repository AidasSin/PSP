using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSPLibrary.Interfaces
{
    public interface IEmailValidator
    {
        public bool CheckEmail(string email);
        public bool CheckIfEmailHasEta(string email);
        public bool CheckEmailForSpecialCharacters(string email, string namePartOfEmail);
        public bool CheckEmailDomain(string domainPartOfEmail);
        public bool CheckEmailSubdomains(List<String> subdomains);
    }
}
