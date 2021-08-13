using OpenQA.Selenium;

namespace Tests
{
    internal class MainPage : Page
    {
        public MainPage(OpenQA.Selenium.IWebDriver driver) : base(driver) { }

        public void openMainPage()
        {
            string test_url = "https://foody.co.il/";
            Driver.Url = test_url;
        }
    }
}