using ABV.Models.HomePage;
using OpenQA.Selenium;
using System.Text;

namespace ABV.Pages.LoginPage
{
    public partial class LoginPage
    {
        /// <summary>
        /// Fill LoginForm fields and press submit button
        /// </summary>
        /// <param name="loginCondition"></param>
        public void LoginForm(LoginCondition loginCondition)
        {
            Type(UsernameField, loginCondition.UsernameField);
            Type(PasswordField, loginCondition.PasswordField);
            SubmitButton.Click();
        }

        public void Login(string username, string password)
        {
            Type(UsernameField, username);
            Type(PasswordField, password);
            SubmitButton.Click();
        }
        /// <summary>
        /// Insert dynamic numbers of chars in input fields
        /// </summary>
        /// <param name="element"></param>
        /// <param name="num"></param>
        public void InsertChars(IWebElement element, int num)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i <= num; i++)
            {
                char c = 'd';
                sb.Append(c).ToString();
            }

            element.SendKeys(sb.ToString());
        }
    }
}
