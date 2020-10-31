using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Reflection;
using Utilities;

namespace ABV.Pages.BasePage
{
    public abstract class BasePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(60));
        }

        public IWebDriver Driver => driver;
        public WebDriverWait Wait => wait;

        public virtual void Navigate()
        {
            Driver.Url = Utilities.GlobalConstants.Url;
        }
        public void Screenshot()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss").ToString();
                screenshot.SaveAsFile($@"D:\Screenshot\Screenshot-{timestamp}.jpg", ScreenshotImageFormat.Png);

            }
        }
        public void Type(IWebElement element, string value)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));
            element.Clear();
            element.SendKeys(value);
        }
        public void StopBrowser()
        {
            Driver.Close();
            Driver.Quit();
        }
        public void BrowserMaximize()
        {
            driver.Manage().Window.Maximize();
        }
        public void ImplicitWait()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }
        public static IWebDriver StartBrowser(BrowserType browserType, BrowserMode browserMode)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    if (browserMode == BrowserMode.Headless)
                    {
                        var options = new ChromeOptions();

                        options.AddArguments("--headless");
                        options.AddArguments("--disable-gpu");
                        options.AddArguments("--test-type");
                        options.AddArguments("--no-first-run");
                        options.AddArguments("--no-default-browser-check");
                        options.AddArguments("--ignore-certificate-errors");
                        options.AddArguments("--start-maximized");
                        options.AddArguments("--window-size=1920,1080");
                        options.AcceptInsecureCertificates = true;

                        return new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), options);
                    }
                    else
                    {
                        var options = new ChromeOptions();

                        options.AcceptInsecureCertificates = true;

                        return new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), options);
                    }

                //TODO: Firefox do not close properly the browser after the completion of the tests.
                case BrowserType.FireFox:
                    if (browserMode == BrowserMode.Headless)
                    {
                        var options = new FirefoxOptions();

                        options.AddArguments("--headless");
                        options.AcceptInsecureCertificates = true;

                        return new FirefoxDriver(options);
                    }
                    else
                    {
                        var options = new FirefoxOptions();

                        options.AcceptInsecureCertificates = true;

                        return new FirefoxDriver(options);
                    }

                //TODO: IE opens tabs in a new window, not in the same.
                case BrowserType.InternetExplorer:
                    {
                        var options = new InternetExplorerOptions();

                        options.EnsureCleanSession = true;

                        return new InternetExplorerDriver(options);
                    }

                default:
                    throw new ArgumentOutOfRangeException(nameof(browserType), browserType, null);
            }
        }
    }
}
