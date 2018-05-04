using NetCoreSauceLabsAutomation.SeleniumObjects.Pages;
using NetCoreSauceLabsAutomation.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreSauceLabsAutomation.AutomationTests
{
    [TestFixture]
    public class GoogleTests : TestBase
    {
        #region TestElements

        private GooglePage page = new GooglePage();

        #endregion

        #region Tests

        [Test]
        [TestCase(OperatingSystems.Windows, Browsers.Chrome)]
        [TestCase(OperatingSystems.Windows, Browsers.Edge)]
        [TestCase(OperatingSystems.Windows, Browsers.IE)]
        [TestCase(OperatingSystems.MacOS, Browsers.Safari)]
        [TestCase(OperatingSystems.Linux, Browsers.Firefox)]
        public void SampleTest(string os, string browser)
        {
            InitializeTest(page, browser, os, true);
            ExecuteTest(SampleTestDefinitions);
        }

        #endregion

        #region Tests Definitions

        private void SampleTestDefinitions()
        {
            page.MakeSimpleSearch();
        }

        #endregion
    }
}
