using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using FluentAssertions;
using OpenQA.Selenium.Firefox;
using Serilog;
public class LoginTests : IDisposable
{
    private readonly IWebDriver driver;
    private readonly LoginPage loginPage;

    public LoginTests(string browser = "firefox") // Par�metro para seleccionar el navegador
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        string projectDirectory = Directory.GetParent(currentDirectory).Parent.FullName;
        string projectDirectory1 = Directory.GetParent(projectDirectory).Parent.FullName;
        string logsDirectory = Path.Combine(projectDirectory1, "Final3", "Logs");
        string logFilePath = Path.Combine(logsDirectory, "log-.txt");
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.File(logFilePath)
            .CreateLogger();
        driver = GetDriver(browser); // Inicializa el driver seg�n el navegador
        loginPage = new LoginPage(driver);

        Console.WriteLine(logFilePath);
    }

    private IWebDriver GetDriver(string browser)//escoge driver para navegador
    {
        return browser.ToLower() switch
        {
            "chrome" => new ChromeDriver(),
            "firefox" => new FirefoxDriver(),
            _ => throw new ArgumentException("Browser not supported.")
        };
    }
    //Test Login form with empty credentials
    [Theory]
    [InlineData("1Any user", "Any pass", "Epic sadface: Username is required")]
    public void UC1_TestLoginWithEmptyCredentials(string username, string password, string expectedError)
    {
        try
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
        catch (Exception ex)
        {
            Log.Error(ex, "Error durante la prueba UC1", ex.Message);
            throw;
        }
    }
    //Test Login form with credentials by passing Username
    [Theory]
    [InlineData("2Any user", "123", "Epic sadface: Password is required")]
    public void UC2_TestLoginWithUsernameOnly(string username, string password, string expectedError)
    {
        try
        {
        driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        loginPage.UserNameField.SendKeys(username);
        loginPage.PasswordField.SendKeys(password);
        loginPage.PasswordField.Clear();
        loginPage.LoginButton.Click();

        var errorMessage = loginPage.ErrorMessage.Text;
        errorMessage.Should().Be(expectedError);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Error durante la prueba UC2", ex.Message);
            throw; // Lanza la excepci�n nuevamente para que xUnit lo registre como fallido
        }
    }
    //Test Login form with credentials by passing valid Username & Password
    [Theory]
    [InlineData("standard_user", "secret_sauce")]
    public void UC3_TestLoginWithValidCredentials(string username, string password)
    {
        try
        {
        driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        loginPage.UserNameField.SendKeys(username);
        loginPage.PasswordField.SendKeys(password);
        loginPage.LoginButton.Click();

        var pageTitle = loginPage.Titulo.Text;
        pageTitle.Should().Be("Swag Labs");
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Error durante la prueba UC3", ex.Message);
            throw;
        }
    }
    public void Dispose()
    {
        driver.Quit();
        Log.CloseAndFlush();
    }
}
