using CSharpSelFramework.PageObjects;
using CSharpSelFramework.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace CSharpSelFramework.Tests
{
    public class Tests : Base
    {
        [Test]
        [TestCase("rahulshettyacademy", "learning")]
        [TestCase("rahulshetty", "learning")]
        public void Test1(string username, string password)
        {
            String[] expectedProducts = { "iphone X", "Blackberry" };
            String[] actualProducts = new string[2];

            LoginPage loginPage = new LoginPage(getDriver());

            ProductsPage productPage = loginPage.validLogin(username, password);
            productPage.weitForPageDisplay();


            IList<IWebElement> products = productPage.getCards();

            foreach (IWebElement product in products)
            {
                if (expectedProducts.Contains(product.FindElement(productPage.getCardTitle()).Text))
                {
                    product.FindElement(productPage.addToCartButton()).Click();
                }
                TestContext.Progress.WriteLine(product.FindElement(By.CssSelector(".card-title a")).Text);
            }

            CheckoutPage checkoutpage = productPage.checkout();

            IList<IWebElement> checkoutCards = checkoutpage.getCards();

            for (int i = 0; i < checkoutCards.Count; i++)
            {
                actualProducts[i] = checkoutCards[i].Text;
            }

            Assert.AreEqual(expectedProducts, actualProducts);

            checkoutpage.checkOut();
        }
    }
}