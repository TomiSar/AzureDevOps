using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using UITests;

namespace SeleniumTests
{
    internal class When
    {
        private IWebDriver driver;
        private TestContext ctx;

        public When(IWebDriver driver, TestContext ctx)
        {
            this.driver = driver;
            this.ctx = ctx;
        }

        internal When IAddTheProductToTheShoppingCart(string category, string productName)
        {
            var homePage = new HomePage(driver, ctx);

            homePage.ClickCategory(category)
                .ClickProduct(productName)
                .AddToCart();

            return this;
        }

        internal When And()
        {
            return this;
        }

        internal void IRegisterANewUser(string username, string email, string password)
        {
            var homepage = new HomePage(driver, ctx);
            homepage.GotoAdminPage()
                .RegisterNewUser(username, email, password);
        }
    }
}