using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace NetCoreSauceLabsAutomation.Utils
{
    public static class SauceLabsConfigurator
    {
        private static IConfiguration Configuration { get; set; }

        internal static IWebDriver GetSauceLabsWebDriver(string os, string browser)
        {
            var sauceLabsUrl = new Uri("https://ondemand.saucelabs.com:443/wd/hub");
            var capabilities = SetDriverCapabilities(os, browser);

            var webDriver = new RemoteWebDriver(sauceLabsUrl, capabilities, TimeSpan.FromSeconds(500));
            webDriver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(10);
            webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            return webDriver;
        }

        private static DesiredCapabilities SetDriverCapabilities(string os, string browser)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("SauceLabsCredentials.json");
            Configuration = builder.Build();

            var capabilities = new DesiredCapabilities();
            capabilities.SetCapability(CapabilityType.Platform, os);
            capabilities.SetCapability(CapabilityType.BrowserName, browser);
            capabilities.SetCapability(CapabilityType.BrowserVersion, "latest");
            capabilities.SetCapability("username", $"{Configuration["username"]}");
            capabilities.SetCapability("accessKey", $"{Configuration["accessKey"]}");
            capabilities.SetCapability("name", $"{TestContext.CurrentContext.Test.ClassName}:{TestContext.CurrentContext.Test.MethodName}: [{TestContext.CurrentContext.Test.Properties.Get("Description")}]");
            return capabilities;
        }
    }
}
