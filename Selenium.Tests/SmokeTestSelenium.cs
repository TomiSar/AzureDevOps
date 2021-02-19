using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.IE;
using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Chrome;
using Selenium.Tests;
using SeleniumTests;

namespace UITests
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [TestClass]
    public class SmokeTestSelenium
    {
        static IWebDriver _driver = null;
        static private Given Given;
        static private When When;
        static private Then Then;

        [ClassInitialize]
        public static void Intialize(TestContext ctx)
        {
            _driver = DriverSelector.SelectDriverFromEnvironment();
            Given = new Given(_driver, ctx);
            When = new When(_driver, ctx);
            Then = new Then(_driver, ctx);

            Given.IHaveACleanDatabaseWithProducts()
                .And()
                .MyWebsiteIsRunning();
        }

        [ClassCleanup]
        public static void CleanUp()
        {
            Given.CleanUp();
            DriverSelector.CleanupDriver(_driver);
        }

  
        [TestMethod]
        public void Selenium_CanRegisterUser()
        {
            Given.IHaveACleanUserDatabase().
                And().
                IAmOnTheHomePage();
            When.IRegisterANewUser("Marcel", "vriesmarcel@hotmail.com", "mypassword123!@");
            Then.ThereWasNoError();
        }

        [TestMethod]
        public void Selenium_CanRegisterForSecondTime()
        {
            Given.IHaveACleanUserDatabase().
                And().
                IAmOnTheHomePage();
            When.IRegisterANewUser("Marcel", "vriesmarcel@hotmail.com", "mypassword123!@");
            Then.ThereWasNoError();
        }
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;
    }
}
