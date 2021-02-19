using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UITests
{
    internal class HomePage : BasePage
    {
   
        public HomePage(IWebDriver driver, TestContext ctx):base(driver,ctx)
        {

        }
        internal ProductDetailPage ClickFirstProduct()
        {
            var productList = FindProductList();
            var hyperlink = FindHyperlinkForFirstProduct(productList);
            ScreenshotManager.TakeScreenshot(driver, ctx);
            if (hyperlink != null)
                hyperlink.Click();
            else
                throw new ArgumentException("Unable to find first product on homepage");

            return new ProductDetailPage(driver, ctx);
        }

        private IWebElement FindHyperlinkForFirstProduct(IWebElement productList)
        {
            var productHyperlinks = productList.FindElements(By.TagName("a"));
            if (productHyperlinks.Count > 0)
                return productHyperlinks[0];
            else
                return null;
        }
        internal bool PageHasProductsListed()
        {
            var element = FindProductList();
            var productLinks = element.FindElements(By.TagName("a"));
            return productLinks.Count > 0;
        }

        private IWebElement FindProductList()
        {
            var productList = driver.FindElement(By.Id("album-list"));
            return productList;
        }

        internal AdminPage GotoAdminPage()
        {
            return new AdminPage(driver, ctx).GotoAdminPage();

        }
    }
}