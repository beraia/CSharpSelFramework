﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace CSharpSelFramework.Utilities
{
    public class Base
    {
        public IWebDriver driver;
        [SetUp]

        public void StartBrowser()
        {
            //Configuration

            String browserName = ConfigurationManager.AppSettings["browser"];
            InitBrowser(browserName);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }

        public IWebDriver getDriver()
        {
            return driver;
        }

        public void InitBrowser(string browserName)
        {
            switch(browserName)
            {
                case "Firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    break;
                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    break;
                case "Edge":
                    driver = new EdgeDriver();
                    break;

            }
        }

        [TearDown] 
        public void AfterTest()
        {
            //driver.Quit();
        }

    }
}
