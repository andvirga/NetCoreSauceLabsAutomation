using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace NetCoreSauceLabsAutomation.SeleniumObjects.Pages
{
    public abstract class BasePage
    {
        /// <summary>
        /// Current Page Base Url
        /// </summary>
        protected abstract Uri BaseUrl { get; }

        /// <summary>
        /// WebDriver used in Current page
        /// </summary>
        protected IWebDriver WebDriver { get; set;  }

        /// <summary>
        /// Goes to a specific Url
        /// </summary>
        /// <param name="Url">Url</param>
        public void GoTo(string Url)
        {
            if (!String.IsNullOrEmpty(Url))
            {
                this.WebDriver.Navigate().GoToUrl(Url);
            }
        }

        public void GoTo()
        {
            this.WebDriver.Navigate().GoToUrl(BaseUrl);
        }

        /// <summary>
        /// Sets the specific driver to the current page
        /// </summary>
        /// <param name="driver">Selenium WebDriver</param>
        public void SetDriverToPage(IWebDriver driver)
        {
            this.WebDriver = driver;
        }
    }
}
