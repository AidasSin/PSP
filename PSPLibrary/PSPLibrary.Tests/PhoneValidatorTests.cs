using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSPLibrary.Tests.Interfaces;

namespace PSPLibrary.Tests
{
	[TestClass]
    class PhoneValidatorTests
    {
		private IPhoneValidator _phoneValidator;

        public PhoneValidatorTests()
        {
            _phoneValidator = new PhoneValidator();
        }

        [TestMethod]
		public void ValidatePhoneNumber_ValidNumber_ReturnsTrue()
		{
			//Arrange
			string number = "+37061111111";

			//Act
			var result = _phoneValidator.CheckNumber(number);

			//Assert
			Assert.AreEqual(true, result);
		}

		[TestMethod]
		public void ValidatePhoneNumber_HasNonNumericSymbol_ReturnsFalse()
		{
			//Arrange
			string number = "+3706111@111";

			//Act
			var result = _phoneValidator.CheckNumber(number);

			//Assert
			Assert.AreEqual(false, result);
		}

		[TestMethod]
		public void ValidatePhoneNumber_IncorrectLenght_ReturnsFalse()
		{
			//Arrange
			string number = "+37061111";

			//Act
			var result = _phoneValidator.CheckNumber(number);

			//Assert
			Assert.AreEqual(false, result);
		}

		[TestMethod]
		public void ValidatePhoneNumber_ValidatesSecondNumberFormat_ReturnsTrue()
		{
			//Arrange
			string number = "861234567";

			//Act
			var result = _phoneValidator.CheckNumber(number);

			//Assert
			Assert.AreEqual(true, result);
		}

		[TestMethod]
		public void ValidatePhoneNumber_ValidateWithAddedNewNumberFormat_ReturnsTrue()
		{
			//Arrange
			string number = "+44123456789";

			//Act
			// Should this test first check if phone would not be validated with +44 prefix
			// and only after that add new format and test phone number?
			// Or just validate the addition of the new format?
			
			_phoneValidator.AddNumberFormat(12, "+44");
			var result = _phoneValidator.CheckNumber(number);

			//Assert
			Assert.AreEqual(true, result);
		}
	}
}
