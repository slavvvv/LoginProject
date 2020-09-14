using OpenQA.Selenium;

namespace ABV.Pages.HomePage
{
    public class HomePage : BasePage.BasePage
    {
        public HomePage(IWebDriver driver)
            : base(driver)
        {

        }
        public IWebElement UserGreetings => Driver.FindElement(By.XPath("//*[@id='middlePagePanel']/div[1]"));
    }
}
