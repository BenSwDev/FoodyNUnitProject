using System;
using OpenQA.Selenium;

namespace Tests
{
    internal class PersonalAreaPage : Page
    {
        private readonly string resgiterElementLinkText = "הירשמו";
        private string mailTextBoxID = "email";
        private string passwordTextBoxID = "password";
        private string loginButtonCssSelector = "#login-form > div.form-group.form-submit.col-12 > button";
        
        public PersonalAreaPage(IWebDriver driver) : base(driver) { }

        public RegisterPage pressOnRegister()
        {
            IWebElement personalAreaElement = Driver.FindElement(By.LinkText(resgiterElementLinkText));
            personalAreaElement.Click();
            return new RegisterPage(Driver);

        }

        internal void fillUpLoginFormAndConnect(string email, string password)
        {
            Driver.FindElement(By.Id(mailTextBoxID)).SendKeys(email);
            Driver.FindElement(By.Id(passwordTextBoxID)).SendKeys(password);

            Driver.FindElement(By.CssSelector(loginButtonCssSelector)).Click();
        }
    }
}