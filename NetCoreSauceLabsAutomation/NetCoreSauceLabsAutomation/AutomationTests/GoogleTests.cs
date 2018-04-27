using NetCoreSauceLabsAutomation.SeleniumObjects.Pages;
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
        public void SampleTest()
        {
            InitializeTest(page);
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
