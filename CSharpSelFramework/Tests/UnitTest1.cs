using CSharpSelFramework.PageObjects;
using CSharpSelFramework.Utilities;
using OpenQA.Selenium;

namespace CSharpSelFramework.Tests
{
    public class Tests : Base
    {
        [Test]
        public void Test1()
        {
            LoginPage loginPage = new LoginPage(getDriver());

            loginPage.validLogin("user1", "password123");
        }
    }
}