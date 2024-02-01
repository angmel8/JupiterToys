using System.Text.Json;

namespace JTTests;

public class JTTestConfig
{
    private readonly string _environment;
    private readonly string _channel;
    private readonly bool _headless;
    private readonly int _slowmo;
    private readonly string _url;

    public JTTestConfig(string filePath)
    {
        string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath);
        string configJsonString = File.ReadAllText(configPath);
        JsonDocument configJsonDocument = JsonDocument.Parse(configJsonString);

        _environment = configJsonDocument.RootElement.GetProperty("environment").ToString();
        _channel = configJsonDocument.RootElement.GetProperty("channel").ToString();
        _headless = bool.Parse(configJsonDocument.RootElement.GetProperty("headless").ToString());
        _slowmo = Int32.Parse(configJsonDocument.RootElement.GetProperty("slowmo").ToString());

        JsonElement configJsonElement = configJsonDocument.RootElement.GetProperty(_environment)[0];

        _url = configJsonElement.GetProperty("URL").ToString();
    }

    public string Environment()
    {
        return _environment;
    }

    public string Channel()
    {
        return _channel;
    }

    public bool Headless()
    {
        return _headless;
    }

    public int SlowMo()
    {
        return _slowmo;
    }

    public string URL()
    {
        return _url;
    }
}