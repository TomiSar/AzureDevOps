using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UITests
{
    internal class ProductDetailPage:BasePage
    { 

        public ProductDetailPage(IWebDriver driver, TestContext ctx):base(driver,ctx)
        {

        }


        private IWebElement FindHyperlink()
        {

            return driver.FindElement(By.PartialLinkText("Add to cart"));
       
        }

        public ShoppingCartPage AddToCart()
        {
            var hyperLink = FindHyperlink();
            ScreenshotManager.TakeScreenshot(driver, ctx);
            hyperLink.Click();
            return new ShoppingCartPage(driver,ctx);
        }
    }
}