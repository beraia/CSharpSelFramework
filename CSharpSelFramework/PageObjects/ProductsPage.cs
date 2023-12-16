using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSelFramework.PageObjects
{
    public class ProductsPage
    {
        IWebDriver _driver;
        By cardTitle = By.CssSelector(".card-title a");
        public ProductsPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public ProductsPage()
        {
        }

        [FindsBy(How = How.TagName, Using = "app-card")]
        private IList<IWebElement> cards;


        //public void waitForPageDisplay()
        //{
        //    WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(8));
        //    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Chekout")));
        //}

        public IList<IWebElement> getCards()
        {
            return cards;
        }

        public By getCardTitle()
        {
            return cardTitle;
        }
    }
}
