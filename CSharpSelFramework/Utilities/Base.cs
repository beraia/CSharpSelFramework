using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System.Configuration;
using WebDriverManager.DriverConfigs.Impl;

namespace CSharpSelFramework.Utilities
{
    public class Base
    {
        public IWebDriver _driver;
        [SetUp]

        public void StartBrowser()
        {
            //Configuration

            String browserName = ConfigurationManager.AppSettings["browser"];
            InitBrowser(browserName);

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            _driver.Manage().Window.Maximize();
            _driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }

        public IWebDriver getDriver()
        {
            return _driver;
        }

        public void InitBrowser(string browserName)
        {
            switch(browserName)
            {
                case "Firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    _driver = new FirefoxDriver();
                    break;
                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    _driver = new ChromeDriver();
                    break;
                case "Edge":
                    _driver = new EdgeDriver();
                    break;

            }
        }

        public static jsonReader getDataParser()
        {
            return new jsonReader();
        }

        [TearDown] 
        public void AfterTest()
        {
            //_driver.Quit();
        }

    }
}
