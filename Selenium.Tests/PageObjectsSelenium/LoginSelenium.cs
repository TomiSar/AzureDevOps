using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace UITests
{
    internal class LoginPage:BasePage
    {
       

        public LoginPage(IWebDriver driver, TestContext ctx):base(driver,ctx)
        {

        }

        internal bool IsCheckoutPageValid()
        {
            
            var element = driver.FindElement(By.CssSelector("#main > form:nth-child(6) > div:nth-child(1) > fieldset:nth-child(1) > p:nth-child(7) > input:nth-child(1)"));

            ScreenshotManager.TakeScreenshot(driver, ctx);
            return element != null;
        }
    }
}