using OpenQA.Selenium;

namespace ABV.Pages.LoginPage
{
    public partial class LoginPage : BasePage.BasePage
    {
        public LoginPage(IWebDriver driver)
            : base(driver)
        {

        }
        public IWebElement UsernameField => Driver.FindElement(By.XPath("//*[@id='username']"));
        public IWebElement PasswordField => Driver.FindElement(By.XPath("//*[@id='password']"));
        public IWebElement SubmitButton => Driver.FindElement(By.XPath("//*[@type='submit']"));
        public IWebElement ErrorMessage => Driver.FindElement(By.XPath("//*[@id='form.errors']"));
    }
}
