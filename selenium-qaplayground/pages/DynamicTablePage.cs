using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace selenium_qaplayground.Pages;

// Dynamic Table Page

// Find the Spider-Man in a table that changes the order of rows and assert his real name

public class DynamicTablePage(IWebDriver driver) : BasePage(driver)
{
    private static By Table => By.CssSelector("table");
    private static By TableHeaders => By.CssSelector("table thead tr th");
    private static By TableBody => By.Id("tbody");

    public void Navigate()
    {
        NavigateTo(AppSettings.Routes.DynamicTable);
    }

    public List<string> GetTableHeader()
    {
        WaitForVisibility(TableHeaders);
        return [.. _driver.FindElements(TableHeaders).Select(el => el.Text)];
    }

    public List<string> GetTableRowByText(string text)
    {
        WaitForVisibility(TableBody);
        var row = _driver.FindElement(
            By.XPath($"//tr[td[contains(., '{text}')]]")
         );
        return [.. row.FindElements(By.TagName("td")).Select(el => el.Text)];
    }

    public IReadOnlyCollection<IWebElement> GetTableRows()
    {
        WaitForVisibility(TableBody);
        return _driver.FindElement(TableBody).FindElements(By.TagName("tr"));
    }
}
