using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

// Add and remove tags and assert tag's presence and count
namespace selenium_qaplayground.Pages
{
    public class TagsInputPage(IWebDriver driver) : BasePage(driver)
    {
        private static By TitleText => By.CssSelector(".title > h2");
        private static By Description => By.CssSelector(".content > p");
        private static By Tags => By.CssSelector(".content ul > li");
        private static By TagRemoveBtn => By.ClassName("uit");
        private static By TagInput => By.CssSelector("input[type='text']");
        private static By RemainingTags => By.CssSelector(".details > p > span");
        private static By RemoveAllBtn => By.XPath("//button[text()='Remove All']");

        public void Navigate()
        {
            NavigateTo(AppSettings.Routes.TagsInput);
        }

        public string GetTitleText()
        {
            return WaitForVisibility(TitleText).Text;
        }

        public string GetDescriptionText()
        {
            return WaitForVisibility(Description).Text;
        }

        public void RemoveAllTags()
        {
            WaitToBeClickable(RemoveAllBtn).Click();
        }

        public void RemoveTag(string tagToRemove)
        {
            var tags = WaitForElements(Tags);
            foreach (var tag in tags)
            {
                if (tag.Text.Trim().Equals(tagToRemove))
                {
                    tag.FindElement(TagRemoveBtn).Click();
                }
            }
        }

        public void AddTag(string tagToAdd)
        {
            WaitToBeClickable(TagInput).SendKeys(tagToAdd + Keys.Enter);
        }

        public List<string> GetTags()
        {
            return [.. WaitForElements(Tags).Select(el => el.Text)];
        }

        public int GetRemainingTagCount()
        {
            return int.Parse(WaitForVisibility(RemainingTags).Text);
        }
    }
}
