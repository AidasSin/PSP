using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSPLibrary.Tests.Interfaces
{
    public interface IEmailValidator
    {
        public bool CheckEmail(string email);
    }
}
