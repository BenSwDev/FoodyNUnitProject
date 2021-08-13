using OpenQA.Selenium;

namespace Tests
{
    public class MainMenu
    {

        internal PersonalAreaPage goToPersonalAreaPage()
        {
            IWebElement personalAreaElement = Page.Driver.FindElement(By.LinkText("אזור אישי"));
            personalAreaElement.Click();
            return new PersonalAreaPage(Page.Driver);
        }
    }
}