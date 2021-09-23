using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Biblioteka;

namespace BibliotekaTests
{
    [TestClass]
    public class PasswordCheckerTests
    {
        [TestMethod]
        public void Password_WhenEmpty_ShouldThrowException()
        {
            var isValid = PasswordChecker.IsPasswordValid("");
        }
    }
}
