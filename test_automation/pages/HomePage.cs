using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace JTTests;

public class HomePage : PageTest
{
    private readonly IPage _page;
    private readonly string _url;
    private readonly ILocator _locatorShopTab;
    private readonly ILocator _locatorContactTab;
    private readonly ILocator _locatorCart;

    public HomePage(IPage page, string filePath)
    {
        _page = page;

        JTTestConfig testConfig = new JTTestConfig(filePath);
        _url = testConfig.URL();

        _locatorShopTab = page.GetByRole(AriaRole.Link, new() { Name = "Shop", Exact = true });
        _locatorContactTab = page.GetByRole(AriaRole.Link, new() { Name = "Contact" });
        _locatorCart = page.GetByRole(AriaRole.Link, new() { Name = "Cart " });
    }

    public async Task GotoAsync()
    {
        await _page.GotoAsync(_url);
    }

    public async Task GotoShopTab()
    {
        await _locatorShopTab.ClickAsync();
    }

    public async Task GotoContactTab()
    {
        await _locatorContactTab.ClickAsync();
    }

    public async Task GotoCart()
    {
        await _locatorCart.ClickAsync();
    }
}