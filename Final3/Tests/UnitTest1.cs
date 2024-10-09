using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using FluentAssertions;
using OpenQA.Selenium.Firefox;
using Serilog;
using Xunit.Sdk;
using FluentAssertions.Execution;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium.BiDi.Communication;

[Collection("LoginTestsCollection")]
public class LoginTests : IClassFixture<BrowserFixture>, IDisposable
{
    private readonly IWebDriver driver;
    private readonly LoginPage loginPage;
    string navegador = "chrome";

    //public BrowserFixture browser;// = new BrowserFixture("firefox");
    //public LoginTests() // Recibe el fixture
    //{
    //    browser = new BrowserFixture();
    //    Console.WriteLine(browser.Browser);
    //    driver = GetDriver(browser.Browser); // Usa el navegador del fixture
    //    loginPage = new LoginPage(driver);
    //    // Aquí también puedes configurar tu logger
    //    string currentDirectory = Directory.GetCurrentDirectory();
    //       string projectDirectory = Directory.GetParent(currentDirectory).Parent.FullName;
    //       string projectDirectory1 = Directory.GetParent(projectDirectory).Parent.FullName;
    //       string logsDirectory = Path.Combine(projectDirectory1, "Final3", "Logs");
    //       string logFilePath = Path.Combine(logsDirectory, "log-.txt");
    //       Log.Logger = new LoggerConfiguration()
    //           .MinimumLevel.Debug()
    //           .WriteTo.File(logFilePath)
    //           .CreateLogger();
    //}

    public LoginTests() // Parámetro para seleccionar el navegador
    {
        //camino para escribir en log los errores
        string currentDirectory = Directory.GetCurrentDirectory();
        string projectDirectory = Directory.GetParent(currentDirectory).Parent.FullName;
        string projectDirectory1 = Directory.GetParent(projectDirectory).Parent.FullName;
        string logsDirectory = Path.Combine(projectDirectory1, "Final3", "Logs");
        string logFilePath = Path.Combine(logsDirectory, "log-.txt");
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.File(logFilePath)
            .CreateLogger();
        driver = GetDriver(navegador); // Inicializa el driver según el navegador
        loginPage = new LoginPage(driver);//instancia loginpage
    }

    private IWebDriver GetDriver(string browser)//escoge navegador
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
            throw; // Lanza la excepción nuevamente para que xUnit lo registre como fallido
        }
    }
    //Test Login form with credentials by passing Username & Password
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
    [CollectionDefinition("LoginTestsCollection", DisableParallelization = true)]
    public class LoginTestsCollection : ICollectionFixture<LoginTests>
    {
        // Esta clase no necesita contener código, se utiliza solo para definir la colección
    }
}
