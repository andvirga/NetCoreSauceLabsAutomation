using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;

namespace NetCoreSauceLabsAutomation.SeleniumObjects.Pages
{
    public class GooglePage : BasePage
    {
        protected override Uri BaseUrl => new Uri("http://www.google.com");

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
