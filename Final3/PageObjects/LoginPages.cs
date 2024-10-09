using OpenQA.Selenium;
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
