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

    /// <summary>
    /// Base class of the automated tests
    /// </summary>
    [TestFixture]
    public class TestBase
    {
        /// <summary>
        /// Indicates if this is a local execution (not SauceLabs)
        /// </summary>
        private bool localExecution = false;

        /// <summary>
        /// Test associated WebDriver
        /// </summary>
        private IWebDriver driver;

        /// <summary>
        /// Initializes the WebDriver depending on the OS and Browser specified 
        /// </summary>
        /// <param name="browser">Browser</param>
        /// <param name="os">OS</param>
        /// <param name="runRemotely">Indicates if the test will run remotely on SauceLabs</param>
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

        /// <summary>
        /// Initializes the test
        /// </summary>
        /// <param name="page">Selenium page to use</param>
        /// <param name="browser">Browser to run the test</param>
        /// <param name="os">OS to run the test</param>
        /// <param name="runRemotely">Indicates if the test will run remotely on SauceLabs</param>
        protected void InitializeTest(BasePage page, string browser, string os, bool runRemotely = false)
        {
            this.InitializeDriver(browser, os, runRemotely);
            page.SetDriverToPage(driver);
            page.GoTo();
        }

        /// <summary>
        /// Executes the test using the supplied test definitions
        /// </summary>
        /// <param name="action">Test Definitions</param>
        protected void ExecuteTest(Action action)
        {
            action();
        }
        
        /// <summary>
        /// Terminates the test execution
        /// </summary>
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

        /// <summary>
        /// Logs the test result to SauceLabs and terminates the webdriver
        /// </summary>
        private void CleanupSauceLabsExecution()
        {
            var passed = TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Passed;

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