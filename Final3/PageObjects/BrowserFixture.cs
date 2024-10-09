public class BrowserFixture : IDisposable
{
    public string Browser { get; private set; }

    public BrowserFixture()
    {
        // Configura el navegador por defecto aquí
        Browser = "chrome"; // Cambia esto si es necesario
    }

    public void Dispose()
    {
        // Aquí puedes manejar cualquier limpieza si es necesario
    }
}
