using NetCoreSauceLabsAutomation.SeleniumObjects.Pages;
using NetCoreSauceLabsAutomation.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.IO;
using System.Reflection;

namespace NetCoreSauceLabsAutomation
{

    [TestFixture]
    public class TestBase
    {
        private bool localExecution = false;
        private IWebDriver driver;

        private void InitializeDriver(string browser, string os, bool runRemotely = false)
        {
            if (runRemotely)
            {
                driver = SauceLabsConfigurator.GetSauceLabsWebDriver(os, browser);   
            }
            else
            {
                localExecution = true;
                switch (browser)
                {
                    case Browsers.Chrome:
                    default:
                        driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                        break;
                    case Browsers.Firefox:
                        driver = new FirefoxDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                        break;
                }
            }
        }

        protected void InitializeTest(BasePage page, string browser, string os, bool runRemotely = false)
        {
            this.InitializeDriver(browser, os, runRemotely);
            page.SetDriverToPage(driver);
            page.GoTo();
        }

        protected void ExecuteTest(Action action)
        {
            action();
        }
        
        [TearDown]
        public void End()
        {
            if (localExecution)
            {
                driver.Quit();
            }
            else
            {
                CleanupSauceLabsExecution();
            }
        }

        private void CleanupSauceLabsExecution()
        {
            var passed = TestContext.CurrentContext.Result.Outcome.Status ==
                         NUnit.Framework.Interfaces.TestStatus.Passed;
            try
            {
                // Logs the result to Sauce Labs
                ((IJavaScriptExecutor)driver).ExecuteScript("sauce:job-result=" + (passed ? "passed" : "failed"));
            }
            finally
            {
                // Terminates the remote webdriver session
                driver.Quit();
            }
        }
    }
}
