using CSharpSelFramework.PageObjects;
using CSharpSelFramework.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CSharpSelFramework.Tests
{
    public class Tests : Base
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        //[TestCase("rahulshettyacademy", "learning")]
        //[TestCase("rahulshetty", "learning")]


        [Parallelizable(ParallelScope.All)]
        public void Test1(string username, string password, String[] expectedProducts)
        {
            //String[] expectedProducts = { "iphone X", "Blackberry" };
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

            _driver.FindElement(By.Id("country")).SendKeys("ind");
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("India")));

            _driver.FindElement(By.LinkText("India")).Click();

            _driver.FindElement(By.CssSelector("label[for*='checkbox2']")).Click();
            _driver.FindElement(By.CssSelector("[value='Purchase']")).Click();

            string confirmText = _driver.FindElement(By.CssSelector(".alert-success")).Text;

            StringAssert.Contains("Success", confirmText);
        }

        public static IEnumerable<TestCaseData> AddTestDataConfig()
        {
            yield return new TestCaseData(getDataParser().extractData("username"), getDataParser().extractData("password"), getDataParser().extractDataArray("products"));
            yield return new TestCaseData(getDataParser().extractData("username_wrong"), getDataParser().extractData("password_wrong"), getDataParser().extractDataArray("products"));
        }
    }
}