using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using UITests;

namespace SeleniumTests
{
    internal class Then
    {
        private IWebDriver driver;
        private TestContext ctx;

        public Then(IWebDriver driver, TestContext ctx)
        {
            this.driver = driver;
            this.ctx = ctx;
        }

        internal Then TheShoppingCartContainsNumberOfItems(int numberOfItemsInCart)
        {
            var cart = new ShoppingCartPage(driver,ctx);
            Assert.AreEqual(numberOfItemsInCart , cart.HasNumberOfItems(numberOfItemsInCart));
            return this;
        }

        internal Then TheShoppingCartTotalEquals(double totalAmount)
        {
            return this;
        }

        internal bool ICanLoginAsUser(string name, string email, string password)
        {
            var adminpage = new AdminPage(driver, ctx).GotoAdminPage();
            return adminpage.LoginAsUser(name, email, password);
        }

        internal void ThereWasNoError()
        {
            return;
        }
    }
}