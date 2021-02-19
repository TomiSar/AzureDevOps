using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace UITests
{
    internal class ShoppingCartPage : BasePage
    {

        public ShoppingCartPage(IWebDriver driver, TestContext ctx) :base(driver,ctx)
        {

        }

        private IWebElement FindHyperlink()
        {

            return driver.FindElement(By.LinkText("Checkout >>"));

        }

        internal LoginPage Checkout()
        {
            var hyperLink = FindHyperlink();
            ScreenshotManager.TakeScreenshot(driver, ctx);
            hyperLink.Click();
            return new LoginPage(driver, ctx);
        }

        internal int HasNumberOfItems(int numberOfItemsInCart)
        {
            //todo:actualy find the number of items in the cart and return this number
            return numberOfItemsInCart;
        }
    }
}