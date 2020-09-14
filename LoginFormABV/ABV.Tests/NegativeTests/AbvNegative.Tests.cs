using NUnit.Framework;

namespace ABV.Tests.NegativeTests
{
    public class AbvNegative : BaseTest
    {
        [Test]
        [TestCase("славтест@абв.бг", Description = "CyrillicLetters")]
        [TestCase("slavtestabv.bg", Description = "WithoutAt")]
        [TestCase("     ", Description = "Spaces")]
        public void CheckUsernameFieldWithNegativeValues(string username)
        {
            loginCondition.UsernameField = username;
            loginPage.LoginForm(loginCondition);
            Assert.AreEqual("Грешен потребител / парола.", loginPage.ErrorMessage.Text);
        }
        [Test]
        public void CheckUsernameFieldWithMoreThenLimitedLengthOfChars()
        {
            loginPage.InsertChars(loginPage.UsernameField, 129);
            Assert.IsFalse(loginPage.UsernameField.GetAttribute("value").Length > 128);
        }
        [Test]
        [TestCase("славТест@", Description = "CyrillicLetters")]
        [TestCase("SLAVTEST@", Description = "Uppercase")]
        [TestCase("     ", Description = "WithSpaces")]
        public void CheckPasswordFieldWithNegativeValues(string passsword)
        {
            loginCondition.PasswordField = passsword;
            loginPage.LoginForm(loginCondition);
            Assert.AreEqual("Грешен потребител / парола.", loginPage.ErrorMessage.Text);
        }
        [Test]
        public void CheckPasswordFieldWithMoreThenLimitedLengthOfChars()
        {
            loginPage.InsertChars(loginPage.PasswordField, 31);
            Assert.IsFalse(loginPage.PasswordField.GetAttribute("value").Length > 30);
        }
    }
}

