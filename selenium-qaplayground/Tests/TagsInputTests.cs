using OpenQA.Selenium;
using selenium_qaplayground.Pages;
using selenium_qaplayground.Utilities;

namespace selenium_qaplayground.Tests
{
    [TestFixture]
    public class TagsInputTests
    {
        private IWebDriver _driver;
        private TagsInputPage _tiPage;

        [SetUp]
        public void SetUp()
        {
            _driver = WebDriverUtility.GetDriver();
            _tiPage = new TagsInputPage(_driver);
            _tiPage.Navigate();
        }

        [Test]
        public void VerifyInitialPageContent()
        {
            var expectedTitle = "Tags";
            var expectedDescription = "Press enter or add a comma after each tag";
            var expectedRemainingTags = 8;
            List<string> expectedTags = ["node", "javascript"];

            var titleText = _tiPage.GetTitleText();
            Assert.That(titleText, Is.EqualTo(expectedTitle));

            var descriptionText = _tiPage.GetDescriptionText();
            Assert.That(descriptionText, Is.EqualTo(expectedDescription));

            var remainingTags = _tiPage.GetRemainingTagCount();
            Assert.That(remainingTags, Is.EqualTo(expectedRemainingTags));

            var tags = _tiPage.GetTags();
            Assert.That(tags, Is.EqualTo(expectedTags));
        }

        [Test]
        public void VerifyAddingTags()
        {
            List<string> tagsToAdd = ["qw", "we", "er", "rt", "ty"];
            List<string> expectedTags = ["node", "javascript", "qw", "we", "er", "rt", "ty"];
            var expectedRemainingTagCount = 3;

            foreach (var tag in tagsToAdd)
            {
                _tiPage.AddTag(tag);
            }

            var tags = _tiPage.GetTags();
            Assert.That(tags, Is.EqualTo(expectedTags));
            var remainingTags = _tiPage.GetRemainingTagCount();
            Assert.That(remainingTags, Is.EqualTo(expectedRemainingTagCount));
        }

        [Test]
        public void VerifyAddingAndRemovingTags()
        {
            List<string> tagsToAdd = ["qw", "we", "er", "rt"];
            List<string> tagsToRemove = ["qw", "rt", "we"];
            List<string> expectedTags = ["er"];
            var expectedRemainingTagCount = 9;

            _tiPage.RemoveAllTags();

            var remainingTagCount = _tiPage.GetRemainingTagCount();
            Assert.That(remainingTagCount, Is.EqualTo(10));

            foreach (var tag in tagsToAdd)
            {
                _tiPage.AddTag(tag);
            }

            foreach (var tag in tagsToRemove)
            {
                _tiPage.RemoveTag(tag);
            }

            var tags = _tiPage.GetTags();
            Assert.That(tags, Is.EqualTo(expectedTags));

            remainingTagCount = _tiPage.GetRemainingTagCount();
            Assert.That(remainingTagCount, Is.EqualTo(expectedRemainingTagCount));
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
