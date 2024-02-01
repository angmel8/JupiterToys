using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using System.Text.Json;

namespace JTTests;

public class ShopPage : PageTest
{
    private readonly IPage _page;
    private readonly JsonElement _products;

    public ShopPage(IPage page, string testCaseNum, string filePath)
    {
        JTTestData testCaseData = new JTTestData(testCaseNum, filePath);

        _products = testCaseData.Products();

        _page = page;
    }

    public async Task AddProducts()
    {
        for (int i=0;i<_products.GetArrayLength();i++)
        {
            string product = _products[i].GetProperty("product").ToString();
            int sequence = Int32.Parse(_products[i].GetProperty("sequence").ToString());
            double price = double.Parse(_products[i].GetProperty("price").ToString());
            int quantity = Int32.Parse(_products[i].GetProperty("quantity").ToString());

            for (int j=0;j<quantity;j++)
                await _page.Locator("#product-" + sequence).GetByRole(AriaRole.Link, new() { Name = "Buy" }).ClickAsync();
        }
    }
}