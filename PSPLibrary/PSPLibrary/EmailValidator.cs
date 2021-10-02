using PSPLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PSPLibrary
{
    public class EmailValidator : IEmailValidator
    {
        public bool CheckEmail(string email)
        {
            if (!CheckIfEmailHasEta(email))
                return false;

            var splitEmail = email.Split('@');
            var namePartOfEmail = splitEmail[0];
            var domainPartOfEmail = splitEmail[1];

            if (CheckEmailForSpecialCharacters(email, namePartOfEmail) &&
                CheckEmailDomain(domainPartOfEmail))
                return true;
            else
                return false;
        }
        public bool CheckIfEmailHasEta(string email)
        {
            if (email.Contains("@"))
                return true;
            else
                return false;
        }
        public bool CheckEmailForSpecialCharacters(string email, string namePartOfEmail)
        {
            var etaCount = email.Count(x => x == '@');
            if (etaCount > 1)
                return false;

            if (namePartOfEmail.Contains("&") ||
                namePartOfEmail.StartsWith("-") ||
                namePartOfEmail.EndsWith("-"))
                return false;

            return true;
        }

        public bool CheckEmailDomain(string domainPartOfEmail)
        {
            if (!domainPartOfEmail.Contains("."))
                return false;

            var splitDomains = domainPartOfEmail.Split(".");
            var TLD = splitDomains[^1];

            List<String> subdomains = new List<String>();

            for (int i = 0; i < splitDomains.Length - 1; i++)
            {
                subdomains.Add(splitDomains[i]);
            }

            if (String.IsNullOrEmpty(domainPartOfEmail) ||
                domainPartOfEmail.StartsWith("-") ||
                domainPartOfEmail.EndsWith("-") ||
                domainPartOfEmail.Length > 63 ||
                domainPartOfEmail.Length < 1 ||
                TLD.Length < 2 || 
                CheckEmailSubdomains(subdomains))
                return false;

            return true;
        }
        public bool CheckEmailSubdomains(List<String> subdomains)
        {
            for (int i = 0; i < subdomains.Count; i++)
            {
                if (String.IsNullOrEmpty(subdomains[i]) ||
                    subdomains[i].StartsWith("-") ||
                    subdomains[i].EndsWith("-") ||
                    subdomains[i].Length > 63 ||
                    subdomains[i].Length < 1)
                    return true;
            }
            return false;
        }
    }
}
