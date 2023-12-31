﻿using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace CSharpSelFramework.PageObjects
{
    public class LoginPage
    {
        private IWebDriver _driver;
        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //Pageobject factory

        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement username;

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement password;

        [FindsBy(How = How.Id, Using = "terms")]
        private IWebElement checkbox;

        [FindsBy(How = How.Id, Using = "signInBtn")]
        private IWebElement signIn;


        public ProductsPage validLogin(string user, string pass)
        {
            username.SendKeys(user);
            password.SendKeys(pass);
            checkbox.Click();
            signIn.Click();

            return new ProductsPage(_driver);
        }
    }
}
