using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace JTTests;

public class JTPage : PageTest
{
    private readonly string _channel;
    private readonly int _slowmo;
    private readonly bool _headless;
    private IPlaywright _playwright = null!;
    private IBrowser _browser = null!;
    private IBrowserContext _context = null!;

    public JTPage(string filePath)
    {
        JTTestConfig testConfig = new JTTestConfig(filePath);

        _channel = testConfig.Channel();
        _headless = testConfig.Headless();
        _slowmo = testConfig.SlowMo();
    }

    public async Task<IPage> NewPage()
    {    
        _playwright = await Microsoft.Playwright.Playwright.CreateAsync();
        _browser = await _playwright.Chromium.LaunchAsync(new() { Headless = _headless, SlowMo = _slowmo, Channel = _channel });
        _context = await _browser.NewContextAsync();

        return await _context.NewPageAsync();
    }

    public async Task Close()
    {
        await _browser.CloseAsync();
    }
}