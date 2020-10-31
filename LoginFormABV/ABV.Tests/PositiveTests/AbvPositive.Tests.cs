using NUnit.Framework;
using Utilities;

namespace ABV.Tests.PositiveTests
{
    public class AbvPositive : BaseTest
    {
        [Test]
        public void CheckUsernameFieldAcceptOneHundredAndTwentyEightChars()
        {
            loginPage.InsertChars(loginPage.UsernameField, 128);
            Assert.IsTrue(loginPage.UsernameField.GetAttribute("value").Length == 128);
        }
        [Test]
        public void CheckPasswordFieldAcceptThirtyChars()
        {
            loginPage.InsertChars(loginPage.PasswordField, 30);
            Assert.IsTrue(loginPage.PasswordField.GetAttribute("value").Length == 30);
        }
        [Test]
        public void CheckLoginFieldsInitialConditionValue()
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual("", loginPage.UsernameField.GetAttribute("value"));
                Assert.AreEqual("", loginPage.PasswordField.GetAttribute("value"));
            });
        }
        [Test]
        public void SuccessfulUserLogin()
        {
            loginPage.Login(GlobalConstants.Username, GlobalConstants.Password);
            Assert.AreEqual(ValidationMessages.WelcomeMessage, homePage.UserGreetings.Text);
        }
        [Test]
        public void CheckErrorMessageText()
        {
            loginCondition.UsernameField = "потребител";
            loginCondition.PasswordField = "парола";
            loginPage.LoginForm(loginCondition);
            Assert.AreEqual(ValidationMessages.ErrorMessage, loginPage.ErrorMessage.Text);
        }
    }
}
