using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Tests
{
    internal class RegisterPage : Page
    {
        public RegisterPage(IWebDriver driver): base(driver) { }

        private readonly string mailTextboxID = "email";
        private readonly string firstNameTextboxID = "first-name";
        private readonly string lastNameTextboxID = "last-name";
        private readonly string passwordTextboxID = "password";
        private readonly string confirmationPasswordTextboxID = "password-confirmation";
        private readonly string phoneTextboxID = "phone-number";
        private readonly string firstCheckboxID = "check-marketing";
        private readonly string secondCheckboxID = "check-e-book";
        private readonly string signUpButton = "#register-form > div.form-group.form-submit.col-12 > button";

        public void fillUpRegistrationForm(string mail, string firstName, string lastName, string password, string phone)
        {
            elementsHandler(mailTextboxID, mail);
            elementsHandler(firstNameTextboxID, firstName);
            elementsHandler(lastNameTextboxID, lastName);
            elementsHandler(passwordTextboxID, password);
            elementsHandler(confirmationPasswordTextboxID, password);
            elementsHandler(phoneTextboxID, phone);
            elementsHandler("//label[@for='" + firstCheckboxID + "']", "");
            elementsHandler("//label[@for='" + secondCheckboxID + "']", "");
        }

        public void clickOnSignUpButton()
        {
            elementsHandler(signUpButton, "");
        }

        private void elementsHandler(string wayToFindElement, string valueOfTextbox)
        {
            try
            {
                if (wayToFindElement.Contains("//"))
                {
                    Driver.FindElement(By.XPath(wayToFindElement)).Click();
                }
                else if (wayToFindElement.Contains("#register-form"))
                {
                    Driver.FindElement(By.CssSelector(wayToFindElement)).Click();
                }
                else
                {
                    Driver.FindElement(By.Id(wayToFindElement)).SendKeys(valueOfTextbox);
                }
            }
            catch
            {

            }
            Thread.Sleep(1500);
        }

    }
}