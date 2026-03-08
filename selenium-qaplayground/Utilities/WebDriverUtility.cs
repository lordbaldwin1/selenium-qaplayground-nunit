using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace selenium_qaplayground.Utilities;

public class WebDriverUtility
{
    public static IWebDriver GetDriver()
    {
        ChromeOptions options = new ChromeOptions();
        // options.AddArgument("headless");
        IWebDriver driver = new ChromeDriver(options);
        driver.Manage().Window.Maximize();
        return driver;
    }
}
