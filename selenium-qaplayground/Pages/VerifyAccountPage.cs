using OpenQA.Selenium;
using selenium_qaplayground.Pages;

namespace selenium_qaplayground.Pages;

public class VerifyAccountPage(IWebDriver driver) : BasePage(driver)
{
    private static By Header => By.Id("title");
    private static By CodeInputs => By.ClassName("code");
    private static By CodeInfo => By.ClassName("info");
    private static By InfoSuccess => By.CssSelector(".info.success");

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
    
    public void FillConfirmationCode(string code)
    {
        var inputs = WaitForElements(CodeInputs).ToList();

        var lengthToFill = Math.Min(inputs.Count, code.Length);
        for (var i = 0; i < lengthToFill; i++)
        {
            inputs[i].SendKeys(code[i].ToString());
        }
    }

    public bool IsSuccessVisible()
    {
        try
        {
            return WaitForVisibility(InfoSuccess).Displayed;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }

    public string GetHeader()
    {
        return WaitForVisibility(Header).Text;
    }
}

