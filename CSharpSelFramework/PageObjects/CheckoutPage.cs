﻿using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace CSharpSelFramework.PageObjects
{
    public class CheckoutPage
    {
        IWebDriver _driver;
        public CheckoutPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "h4 a")]
        private IList<IWebElement> checkoutCards;

        [FindsBy(How = How.CssSelector, Using = ".btn-success")]
        private IWebElement checkoutButton;

        public IList<IWebElement> getCards()
        {
            return checkoutCards;
        }

        public void checkOut()
        {
            checkoutButton.Click();
            //object of next page
        }
    }
}
