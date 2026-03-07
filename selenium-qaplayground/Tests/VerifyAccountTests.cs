using OpenQA.Selenium;
using selenium_qaplayground.Pages;
using selenium_qaplayground.Utilities;

namespace selenium_qaplayground.Tests;

[TestFixture]
public class VerifyAccountTests
{
    private IWebDriver _driver;
    private VerifyAccountPage _vaPage;

    [SetUp]
    public void Setup()
    {
        _driver = WebDriverUtility.GetDriver();
        _vaPage = new VerifyAccountPage(_driver);
        _vaPage.Navigate();
    }

    [Test]
    public void VerifySuccessfulCodeEntry()
    {
        var expectedCode = "999999";

        var code = _vaPage.GetConfirmationCode();
        Assert.That(code, Is.EqualTo(expectedCode));

        _vaPage.FillConfirmationCode(code);
        var isSuccess = _vaPage.IsSuccessVisible();
        Assert.That(isSuccess, Is.True, "Success message not showing");
    }


    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
        _driver.Dispose();
    }
}
