using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using System.Text.Json;

namespace JTTests;

public class CartPage : PageTest
{
    private readonly IPage _page;
    private readonly JsonElement _products;
    private readonly ILocator _locatorBody;
    private readonly ILocator _locatorTotal;

    public CartPage(IPage page, string testCaseNum, string filePath)
    {
        JTTestData testCaseData = new JTTestData(testCaseNum, filePath);

        _products = testCaseData.Products();

        _page = page;
        _locatorBody = page.Locator("tbody");
        _locatorTotal = page.GetByRole(AriaRole.Strong);
    }

    public async Task VerifyProducts()
    {
        double total = 0.00;
        JTFinancials financials = new JTFinancials();

        for (int i=0;i<_products.GetArrayLength();i++)
        {
            string price = _products[i].GetProperty("price").ToString();
            string quantity = _products[i].GetProperty("quantity").ToString();
            string subtotal = financials.CalculateSubtotal(price, quantity);

            total = total + double.Parse(subtotal);

            await Expect(_locatorBody).ToContainTextAsync("$" + price);
            await Expect(_locatorBody).ToContainTextAsync("$" + subtotal);
        }

        await Expect(_locatorTotal).ToContainTextAsync("Total: " + total.ToString());
    }
}