using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace UITests
{
    internal class AdminPage : BasePage
    {

        public AdminPage(IWebDriver driver, TestContext ctx) : base(driver,ctx)
        {

        }

        public AdminPage RegisterNewUser(string name, string email, string password)
        {
            driver.FindElement(By.LinkText("Register")).Click();

            driver.FindElement(By.Id("UserName")).SendKeys(name);
            driver.FindElement(By.Id("Email")).SendKeys(email);
            driver.FindElement(By.Id("Password")).SendKeys(password);
            driver.FindElement(By.Id("ConfirmPassword")).SendKeys(password);

            driver.FindElement(By.Id("Register")).Click();

            return this;
        }

        internal bool LoginAsUser(string name, string email, string password)
        {
            driver.FindElement(By.Id("UserName")).SendKeys(name);
            driver.FindElement(By.Id("Password")).SendKeys(password);

            driver.FindElement(By.TagName("Input")).Click();
            return true;
        }

        public AdminPage GotoAdminPage()
        {
            driver.FindElement(By.LinkText("Admin")).Click();
            return this;
        }
                    
    }
}