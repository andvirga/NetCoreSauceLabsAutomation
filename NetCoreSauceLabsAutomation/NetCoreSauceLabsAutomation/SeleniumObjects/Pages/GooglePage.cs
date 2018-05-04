using System;
using System.Threading;
using OpenQA.Selenium;

namespace NetCoreSauceLabsAutomation.SeleniumObjects.Pages
{
    /// <summary>
    /// Represents the Google search page
    /// </summary>
    public class GooglePage : BasePage
    {
        protected override Uri BaseUrl => new Uri("http://www.google.com");

        /// <summary>
        /// Commands to execute on the webdriver when performing the MakeSimpleSearch test
        /// </summary>
        public void MakeSimpleSearch()
        {
            var searchBar = WebDriver.FindElement(By.Id("lst-ib"));
            searchBar.Clear();
            searchBar.SendKeys("SauceLabs");
            WebDriver.FindElement(By.Id("hplogo")).Click();
            var searchBtn = WebDriver.FindElement(By.Name("btnK"));
            searchBtn.Click();
            Thread.Sleep(2000);
        }
    }
}
