using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
public class LoginPage
{
    private readonly IWebDriver driver;
    private readonly WebDriverWait wait;

    public LoginPage(IWebDriver driver)
    {
        this.driver = driver;
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
    }

    public IWebElement UserNameField => wait.Until(d => d.FindElement(By.XPath("//input[@id='user-name']")));
    public IWebElement PasswordField => wait.Until(d => d.FindElement(By.XPath("//input[@id='password']")));
    public IWebElement LoginButton => wait.Until(d => d.FindElement(By.XPath("//input[@id='login-button']")));
    public IWebElement ErrorMessage => wait.Until(d => d.FindElement(By.XPath("//h3[@data-test='error']")));
    public IWebElement Titulo => wait.Until(d => d.FindElement(By.XPath("//*[@id='header_container']/div[1]/div[2]/div")));
}
