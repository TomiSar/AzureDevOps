using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace UITests
{
    internal class BasePage
    {
        protected IWebDriver driver;
        protected TestContext ctx;

        public BasePage(IWebDriver driver, TestContext ctx)
        {
            this.driver = driver;
            this.ctx = ctx;
        }

        internal ProductBrowsePage ClickCategory(string categoryName)
        {
            var HyperLink = FindHyperlinkforProductCategory(categoryName);
            HyperLink.Click();
            return new ProductBrowsePage(driver,ctx);
        }
        private IWebElement FindHyperlinkforProductCategory(string categoryName)
        {
            var productCategories = driver.FindElement(By.Id("categories"));
            return productCategories.FindElement(By.LinkText(categoryName));
        }


    }
}