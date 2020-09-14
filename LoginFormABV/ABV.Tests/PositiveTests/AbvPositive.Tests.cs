using NUnit.Framework;

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
            loginPage.Login(Utilities.GlobalConstants.Username, Utilities.GlobalConstants.Password);
            Assert.AreEqual("Здравейте, Слав Слав (slavtest@abv.bg)", homePage.UserGreetings.Text);
        }
        [Test]
        public void CheckErrorMessageText()
        {
            loginCondition.UsernameField = "потребител";
            loginCondition.PasswordField = "парола";
            loginPage.LoginForm(loginCondition);
            Assert.AreEqual("Грешен потребител / парола.", loginPage.ErrorMessage.Text);
        }
    }
}
