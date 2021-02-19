using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Tests
{
    static class DriverSelector
    {
        public static IWebDriver SelectDriverFromEnvironment()
        {
            var envVar = Environment.GetEnvironmentVariable("SeleniumDriver");
            IWebDriver driver = null;
            switch (envVar)
            {
                case "FirefoxDriver":
                    driver = new FirefoxDriver();
                    break;
                case "EdgeDriver":
                    driver = new EdgeDriver();
                    break;
                case "InternetExplorerDriver":
                    driver = new InternetExplorerDriver();
                    break;
                case "ChromeDriver":
                default:
                    driver = new ChromeDriver();
                    break;
            }

            return driver;
        }

        internal static void CleanupDriver(IWebDriver driver)
        {
            try
            {
                //driver.Quit();// quit does not close the window
                driver.Close();
                driver.Dispose();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
    }
}
