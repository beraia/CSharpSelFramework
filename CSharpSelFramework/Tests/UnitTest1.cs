using CSharpSelFramework.PageObjects;
using CSharpSelFramework.Utilities;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace CSharpSelFramework.Tests
{
    public class Tests : Base
    {
        [Test]
        public void Test1()
        {
            String[] expectedProducts = { "iphone X", "Blackberry" };
            String[] actualProducts = new string[2];

            LoginPage loginPage = new LoginPage(getDriver());

            ProductsPage productPage = loginPage.validLogin("rahulshettyacademy", "learning");
            //productPage.waitForPageDisplay();

            IList<IWebElement> products = productPage.getCards();

            foreach (IWebElement product in products)
            {
                if (expectedProducts.Contains(product.FindElement(productPage.getCardTitle()).Text))
                {
                    product.FindElement(By.CssSelector(".card-footer button")).Click();
                }
                TestContext.Progress.WriteLine(product.FindElement(By.CssSelector(".card-title a")).Text);
            }
        }
    }
}