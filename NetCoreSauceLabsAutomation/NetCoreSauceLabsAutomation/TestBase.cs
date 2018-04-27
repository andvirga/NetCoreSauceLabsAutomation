using NetCoreSauceLabsAutomation.SeleniumObjects.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;

namespace NetCoreSauceLabsAutomation
{

    [TestFixture]
    public class TestBase
    {
        private IWebDriver driver;

        [SetUp]
        public void Init()
        {
            InitializeDriver();
        }

        private void InitializeDriver()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }

        protected void InitializeTest(BasePage page)
        {
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
            driver.Quit();
        }
    }
}
