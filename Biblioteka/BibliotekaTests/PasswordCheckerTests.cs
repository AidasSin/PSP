using Microsoft.VisualStudio.TestTools.UnitTesting;
using Biblioteka;

namespace BibliotekaTests
{
    [TestClass]
    public class PasswordCheckerTests
    {
        readonly PasswordChecker passwordChecker = new PasswordChecker();
        [TestMethod]
        public void Password_WhenEmpty_ShouldNotBeValid()
        {
            var isPasswordValid = passwordChecker.IsPasswordValid(" ");
            Assert.AreEqual(false, isPasswordValid,"The password is not valid because it's empty");
        }
        [TestMethod]
        public void Password_WhenNull_ShouldNotBeValid()
        {
            var isPasswordValid = passwordChecker.IsPasswordValid(null);
            Assert.AreEqual(false, isPasswordValid, "The password is not valid because the value provided is a null");
        }
        [TestMethod]
        public void Password_WhenShorterThan8Symbols_ShouldNotBeValid()
        {
            var isPasswordValid = passwordChecker.IsPasswordValid("shhh");
            Assert.AreEqual(false, isPasswordValid, "The password is not valid because it's shorter than 8 symbols.");
        }
        [TestMethod]
        public void Password_WhenWithoutUppercaseSymbols_ShouldNotBeValid()
        {
            var isPasswordValid = passwordChecker.IsPasswordValid("nouppercase");
            Assert.AreEqual(false, isPasswordValid, "The password is not valid because it doesn't have any uppercase symbols.");
        }
        [TestMethod]
        public void Password_WhenWithoutSpecialSymbol_ShouldNotBeValid()
        {
            var isPasswordValid = passwordChecker.IsPasswordValid("nouppercase");
            Assert.AreEqual(false, isPasswordValid, "The password is not valid because it doesn't have any of the special symbols.");
        }

    }
}
