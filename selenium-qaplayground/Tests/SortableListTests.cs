using OpenQA.Selenium;
using selenium_qaplayground.Pages;
using selenium_qaplayground.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace selenium_qaplayground.Tests
{
    [TestFixture]
    public class SortableListTests
    {
        private IWebDriver _driver;
        private SortableListPage _slPage;

        [SetUp]
        public void SetUp()
        {
            _driver = WebDriverUtility.GetDriver();
            _slPage = new SortableListPage(_driver);
            _slPage.Navigate();
        }

        [Test]
        public void VerifySuccessfulSortOrder()
        {
            _slPage.SortList();
            var test = 0;
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
