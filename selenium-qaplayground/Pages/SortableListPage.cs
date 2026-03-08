using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

// Drag and drop list items to make the correct order and 
// then click on the button and assert that all have green text

//export const topList = [
//  { position: 0, name: "Jeff Bezos" },
//  { position: 1, name: "Bill Gates" },
//  { position: 2, name: "Warren Buffett" },
//  { position: 3, name: "Bernard Arnault" },
//  { position: 4, name: "Carlos Slim Helu" },
//  { position: 5, name: "Amancio Ortega" },
//  { position: 6, name: "Larry Ellison" },
//  { position: 7, name: "Mark Zuckerberg" },
//  { position: 8, name: "Michael Bloomberg" },
//  { position: 9, name: "Larry Page" },
//];

namespace selenium_qaplayground.Pages
{
    public class TopListItem
    {
        public required int Position { get; set; }
        public required string Name { get; set; }
    }

    public static class TopListData
    {
        public static List<TopListItem> TopList = [
        new TopListItem { Position = 0, Name = "Jeff Bezos" },
        new TopListItem { Position = 1, Name = "Bill Gates" },
        new TopListItem { Position = 2, Name = "Warren Buffett" },
        new TopListItem { Position = 3, Name = "Bernard Arnault" },
        new TopListItem { Position = 4, Name = "Carlos Slim Helu" },
        new TopListItem { Position = 5, Name = "Amancio Ortega" },
        new TopListItem { Position = 6, Name = "Larry Ellison" },
        new TopListItem { Position = 7, Name = "Mark Zuckerberg" },
        new TopListItem { Position = 8, Name = "Michael Bloomberg" },
        new TopListItem { Position = 9, Name = "Larry Page" }
        ];
    }
 
    public class SortableListPage(IWebDriver driver) : BasePage(driver)
    {
        private static By ListItems => By.CssSelector("#draggable-list > li");

        public void Navigate()
        {
            NavigateTo(AppSettings.Routes.SortableList);
        }

        public void SortList()
        {
            WaitForElements(ListItems);
            var actions = new Actions(driver);
            foreach (var item in TopListData.TopList)
            {
                var sourceElement = driver.FindElement(By.XPath($"//li[.//p[contains(text(), '{item.Name}')]]"));
                var targetElement = driver.FindElement(By.CssSelector($"li[data-index='{item.Position}']"));
                actions.DragAndDrop(sourceElement, targetElement).Perform();
            }
        }
    }
}
