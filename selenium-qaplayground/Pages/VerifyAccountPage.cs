using OpenQA.Selenium;
using selenium_qaplayground.Pages;

namespace selenium_qaplayground.Pages;

public class VerifyAccountPage(IWebDriver driver) : BasePage(driver)
{
    private static By Header => By.Id("title");
    private static By CodeContainer => By.ClassName("code-container");
    private static By CodeInfo => By.ClassName("info");

    public void Navigate()
    {
        NavigateTo(AppSettings.Routes.VerifyAccount);
    }
    public string GetConfirmationCode()
    {
        var codeText = WaitForVisibility(CodeInfo).Text;
        var code = codeText.Trim().Split(" ")[4];
        return code.Replace("-", "");
    }

    public string GetHeader()
    {
        return WaitForVisibility(Header).Text;
    }
}

