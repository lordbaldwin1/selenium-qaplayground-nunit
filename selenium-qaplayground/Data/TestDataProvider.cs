

namespace selenium_qaplayground.Data
{
    public class TagTestData
    {
        public required List<string> TagsToAdd { get; set; }
        public required List<string> TagsToRemove { get; set; }
        public required List<string> ExpectedTags { get; set; }
        public int ExpectedRemainingTagCount { get; set; }
    }

    public class TestDataProvider
    {
        public static IEnumerable<TestCaseData> TagManagementTestCases()
        {
            yield return new TestCaseData(
                new TagTestData
                {
                    TagsToAdd = ["qw", "we", "er", "rt"],
                    TagsToRemove = ["qw", "rt", "we"],
                    ExpectedTags = ["er"],
                    ExpectedRemainingTagCount = 9
                }
            ).SetName("AddAndRemoveMultipleTags");

            yield return new TestCaseData(
                new TagTestData
                {
                    TagsToAdd = ["tag1", "tag2"],
                    TagsToRemove = [],
                    ExpectedTags = ["tag1", "tag2"],
                    ExpectedRemainingTagCount = 8
                }
            ).SetName("AddTagsWithoutRemoval");
        }
    }
}
