using ABV.Factory.HomePage;
using ABV.Models.HomePage;
using ABV.Pages.BasePage;
using ABV.Pages.HomePage;
using ABV.Pages.LoginPage;
using NUnit.Framework;
using OpenQA.Selenium;
using Utilities;

namespace ABV.Tests
{
    [TestFixture]
    public class BaseTest
    {
        private IWebDriver driver;
        protected LoginPage loginPage;
        protected HomePage homePage;
        protected LoginCondition loginCondition;

        [SetUp]
        public void Init()
        {
            driver = BasePage.StartBrowser(BrowserType.Chrome, BrowserMode.Headless);
            loginPage = new LoginPage(driver);
            homePage = new HomePage(driver);
            loginPage.Navigate();
            loginPage.BrowserMaximize();
            loginPage.ImplicitWait();
            loginCondition = LoginFactory.CreatLoginForm();
        }
        [TearDown]
        public void QuitBrowser()
        {
            loginPage.Screenshot();
            loginPage.StopBrowser();
        }
    }
}
