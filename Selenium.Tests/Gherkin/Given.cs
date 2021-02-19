using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SeleniumTests
{
    internal class Given
    {
        private IWebDriver _driver;
        private TestContext ctx;
        private List<string> _containerIds = new List<string>();
        private string _websiteRootPage;
        public Given(IWebDriver driver, TestContext ctx)
        {
            _driver = driver;
            this.ctx = ctx;
        }

        internal Given MyWebsiteIsRunning()
        {
            var ipadressWebsiteAndContainerID = ContainerManager.StartWebsite("musicstore").Result;
            _driver.Url = $"http://{ipadressWebsiteAndContainerID.Item1}";
            _websiteRootPage = _driver.Url;
            //_driver.Url = "localhost:26641";
            _driver.Navigate();
            _containerIds.Add(ipadressWebsiteAndContainerID.Item2);
            return this;
        }
        internal Given IAmOnTheHomePage()
        {
            _driver.Url = _websiteRootPage;
            _driver.Navigate();
            return this;
        }

        internal Given And()
        {
            return this;
        }

        internal Given IHaveACleanDatabaseWithProducts()
        {
            var container_id = ContainerManager.StartCleanMusicstoreDatabaseContainer("db").Result;
            _containerIds.Add(container_id);
            return this;
        }

        internal Given IHaveACleanUserDatabase()
        {
            var containerRemoved = ContainerManager.RemoveContainerWithName("aspnetdb").Result;
            if (containerRemoved)
            {
                ctx.WriteLine("Removed container with name: aspnetdb");
                // we switched the db contianer, that means we can get a new container with a new IP
                // we need to flush the DNS in the web application container, so it will
                // resolve a new query to the database to a new IP
                if (!ContainerManager.ExecuteCommandInContainer("musicstore",new List<string>() { "ipconfig","/flushdns" }).Result)
                {
                    throw new ArgumentException("Unable to flush the DNS cach on the webserver");
                }
            }
            var container_id = ContainerManager.StartCleanUserDatabaseContainer("aspnetdb").Result;
            _containerIds.Add(container_id);
            return this;
        }

        internal void CleanUp()
        {
            Task.WaitAll(
            ContainerManager.CleanupContainers(_containerIds));
        }
    }
}