using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace selenium_qaplayground.Pages;

public abstract class BasePage
{
    protected readonly IWebDriver _driver;
    protected readonly WebDriverWait _wait;

    protected BasePage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
    }

    protected void NavigateTo(string route)
    {
        string URL = AppSettings.GetUrl(route);
        _driver.Navigate().GoToUrl(URL);
    }

    protected IWebElement WaitForVisibility(By locator)
    {
        return _wait.Until(ExpectedConditions.ElementIsVisible(locator));
    }

    protected IWebElement WaitToBeClickable(By locator)
    {
        return _wait.Until(ExpectedConditions.ElementToBeClickable(locator));
    }

    protected IWebElement WaitForElement(By locator)
    {
        return _wait.Until(ExpectedConditions.ElementExists(locator));
    }

    protected IEnumerable<IWebElement> WaitForElements(By locator)
    {
        return _wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator));
    }
}
