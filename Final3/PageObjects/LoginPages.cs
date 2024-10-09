using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using Xunit;

public static class DriverHelper
{
    private static IWebDriver driver;

    public static IWebDriver GetDriver(string browser)
    {
        if (driver != null)
        {
            return driver; // Retorna el driver existente si ya está inicializado
        }

        switch (browser.ToLower())
        {
            case "chrome":
                driver = new ChromeDriver();
                break;
            case "firefox":
                driver = new FirefoxDriver();
                break;
            default:
                throw new InvalidOperationException("Browser not supported.");
        }

        return driver;
    }

    public static void CloseDriver()
    {
        if (driver != null)
        {
            driver.Quit();
            driver = null;
        }
    }
}

public class LoginPage
{
    private readonly IWebDriver driver;

    public LoginPage(IWebDriver driver)
    {
        this.driver = driver;
    }

    public IWebElement UserNameField => driver.FindElement(By.XPath("//input[@id='user-name']"));
    public IWebElement PasswordField => driver.FindElement(By.XPath("//input[@id='password']"));
    public IWebElement LoginButton => driver.FindElement(By.XPath("//input[@id='login-button']"));
    public IWebElement ErrorMessage => driver.FindElement(By.XPath("//h3[@data-test='error']"));
    public IWebElement titulo => driver.FindElement(By.XPath("//*[@id=\"header_container\"]/div[1]/div[2]/div"));
}
