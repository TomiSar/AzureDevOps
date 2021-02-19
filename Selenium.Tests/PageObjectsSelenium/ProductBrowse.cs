using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Linq;

namespace UITests
{
    internal class ProductBrowsePage : BasePage
    {
        public ProductBrowsePage(IWebDriver driver, TestContext ctx) : base(driver, ctx)
        {

        }

        public ProductDetailPage ClickProduct(string productName)
        {
            IWebElement productElement = FindProductLink(productName);
            productElement.Click();
            return new ProductDetailPage(driver, ctx);
        }

        private IWebElement FindProductLink(string productName)
        {
            var products = driver.FindElements(By.LinkText(productName));
            if (products.Count > 0)
                return products.First();
            else
                return null;
        }

        public bool DoesProductExistOnPage(string productName)
        {
            var productLink = FindProductLink(productName);
            return productLink != null;
        }
    }
}