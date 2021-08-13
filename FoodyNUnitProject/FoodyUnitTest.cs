using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Threading;

namespace Tests
{
    public class Tests
    {
        private IWebDriver driver;
        private string email = "testbsw9999999999@walla.com";
        private string password = "Passw0rd";

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(Environment.CurrentDirectory + @"\Drivers\");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void FillUpRegistrationForm()
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.openMainPage();
            PersonalAreaPage personalAreaPage = mainPage.mainMenu.goToPersonalAreaPage();
            RegisterPage registerPage = personalAreaPage.pressOnRegister();
            registerPage.fillUpRegistrationForm(email, "test", "test2",password, "0597778672");
            registerPage.clickOnSignUpButton();

            // i dont have site key and secret key to disable reCAPTCHA 
            // therefor this is the end of this test
            // if you want to check it anyway, the way to check is:
            //driver.PageSource.Contains("test") 
            //it means the username appears on main page.

            Thread.Sleep(6000);
        }

        [Test]
        public void LoginAfterRegistration()
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.openMainPage();
            PersonalAreaPage personalAreaPage = mainPage.mainMenu.goToPersonalAreaPage();
            personalAreaPage.fillUpLoginFormAndConnect(email,"passw0rd1"); 
            //entered a wrong password 
            //need to fail!
            Thread.Sleep(4000);

            if (driver.PageSource.Contains("נכשלה"))
            {
                personalAreaPage.fillUpLoginFormAndConnect("", password); 
                //email is already in textbox
            }
            Thread.Sleep(6000);
        }

        [TearDown]
        public void close_Browser()
        {
            driver.Quit();
        }
    }
}