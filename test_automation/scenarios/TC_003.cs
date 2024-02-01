using Microsoft.Playwright.NUnit;
using JTTests;

public class TC_003 : PageTest
{
    const string configPath = "../../../test_automation/config/config.json";
    const string testDataPath = "../../../test_automation/data/testData.json";

    [Test]
    public async Task TestCase()
    {
        var jtPage = new JTPage(configPath);
        var page = await jtPage.NewPage();

        var homePage = new HomePage(page, configPath);
        await homePage.GotoAsync();
        await homePage.GotoShopTab();

        var purchase = new JTPurchase(page, "TC_003", testDataPath);
        await purchase.AddToCart();

        await homePage.GotoCart();
        await purchase.VerifyCart();

        await jtPage.Close();

        Console.Write("TC_003: Buy multiple products and verify prices, subtotals and total");
    }
}