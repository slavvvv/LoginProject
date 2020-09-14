using NUnit.Framework;


namespace ABV.Tests.CrashTests
{
    public class AbvCrash : BaseTest
    {
        [Test]
        [TestCase("Robert'); DROP TABLE Students;--", Description = "SQLInjection")]
        [TestCase("<script>alert('Executing JS')</script>", Description = "JSScriptInjection")]
        [TestCase("<click>Button</click>", Description = "HTMLTag")]
        public void CheckUsernameFieldWithCrashValues(string username)
        {
            loginCondition.UsernameField = username;
            loginPage.LoginForm(loginCondition);
            Assert.AreEqual("Грешен потребител / парола.", loginPage.ErrorMessage.Text);
        }
        [Test]
        [TestCase("Robert'); DROP TABLE Students;--", Description = "SQLInjection")]
        [TestCase("<script>alert('Executing JS')</script>", Description = "JSScriptInjection")]
        [TestCase("<click>Button</click>", Description = "HTMLTag")]
        public void CheckPasswordFieldWithCrashValues(string password)
        {
            loginCondition.PasswordField = password;
            loginPage.LoginForm(loginCondition);
            Assert.AreEqual("Грешен потребител / парола.", loginPage.ErrorMessage.Text);
        }
    }
}
