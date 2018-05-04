using NetCoreSauceLabsAutomation.SeleniumObjects.Pages;
using NetCoreSauceLabsAutomation.Utils;
using NUnit.Framework;

namespace NetCoreSauceLabsAutomation.AutomationTests
{
    /// <summary>
    /// Google Test Fixture
    /// </summary>
    [TestFixture]
    public class GoogleTests : TestBase
    {
        #region Test Elements

        /// <summary>
        /// Google page
        /// </summary>
        private GooglePage page = new GooglePage();

        #endregion

        #region Tests

        /// <summary>
        /// Sample test of a simple search on Google
        /// </summary>
        /// <param name="os">OS to run the test</param>
        /// <param name="browser">Browser to run the test</param>
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

        /// <summary>
        /// Test definitions of the SampleTest
        /// </summary>
        private void SampleTestDefinitions()
        {
            page.MakeSimpleSearch();
        }

        #endregion
    }
}
