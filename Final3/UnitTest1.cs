using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using FluentAssertions;
public class LoginTests : IDisposable
{
    private readonly IWebDriver driver;
    private readonly LoginPage loginPage;

    public LoginTests()
    {
        driver = new ChromeDriver();
        loginPage = new LoginPage(driver);
    }

    [Theory]
    [InlineData("1Any user", "Any pass", "Epic sadface: Username is required")]
    public void UC1_TestLoginWithEmptyCredentials(string username, string password, string expectedError)
    {
        driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        loginPage.UserNameField.SendKeys(username);
        loginPage.PasswordField.SendKeys(password);
        loginPage.UserNameField.Clear();
        loginPage.PasswordField.Clear();
        loginPage.LoginButton.Click();

        var errorMessage = loginPage.ErrorMessage.Text;
        errorMessage.Should().Be(expectedError);
    }

    [Theory]
    [InlineData("2Any user", "123", "Epic sadface: Password is required")]
    public void UC2_TestLoginWithUsernameOnly(string username, string password, string expectedError)
    {
        driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        loginPage.UserNameField.SendKeys(username);
        loginPage.PasswordField.SendKeys(password);
        loginPage.PasswordField.Clear();
        loginPage.LoginButton.Click();

        var errorMessage = loginPage.ErrorMessage.Text;
        errorMessage.Should().Be(expectedError);
    }

    [Theory]
    [InlineData("standard_user", "secret_sauce")]
    public void UC3_TestLoginWithValidCredentials(string username, string password)
    {
        driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        loginPage.UserNameField.SendKeys(username);
        loginPage.PasswordField.SendKeys(password);
        loginPage.LoginButton.Click();

        var pageTitle = loginPage.titulo.Text;
        pageTitle.Should().Be("Swag Labs");
    }

    public void Dispose()
    {
        driver.Quit();
    }
}
