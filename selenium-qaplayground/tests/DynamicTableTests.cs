using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using selenium_qaplayground.pages;

namespace selenium_qaplayground.tests;

public class DynamicTableTests
{
    private IWebDriver _driver;
    private DynamicTablePage _dtPage;

    [SetUp]
    public void Setup()
    {
        _driver = new ChromeDriver();
        _dtPage = new DynamicTablePage(_driver);
        _dtPage.Navigate();
    }

    [Test]
    public void VerifyTableHeaders()
    {
        List<string> expectedHeaders = ["SUPERHERO", "STATUS", "REAL NAME"];
        var headers = _dtPage.GetTableHeader();
        Assert.That(headers, Is.EqualTo(expectedHeaders));
    }

    [Test]
    public void VerifyPeterParker()
    {
        var row = _dtPage.GetTableRowByText("Spider-Man");
        Assert.That(row, Does.Contain("Peter Parker"));
        Assert.That(row, Does.Contain("Active"));
    }

    [Test]
    public void VerifyRowCount()
    {
        var rows = _dtPage.GetTableRows();
        Assert.That(rows, Has.Count.EqualTo(8));
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
        _driver.Dispose();
    }
}
