using OpenQA.Selenium;

namespace Tests
{
    internal class Page
    {
        public static IWebDriver Driver { get; set; }
        public MainMenu mainMenu;

        public Page(IWebDriver iDriver)
        {
            Driver = iDriver;
            mainMenu = new MainMenu();
        }
    }
}