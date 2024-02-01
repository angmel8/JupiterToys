using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace JTTests;

public class JTPurchase : PageTest
{
    private readonly IPage _page;
    private readonly string _testCaseNum;
    private readonly string _testDataPath;

    public JTPurchase(IPage page, string testCaseNum, string testDataPath)
    {
        _page = page;
        _testCaseNum = testCaseNum;
        _testDataPath = testDataPath;
    }

    public async Task AddToCart()
    {    
        var shopPage = new ShopPage(_page, _testCaseNum, _testDataPath);

        await shopPage.AddProducts();
    }

    public async Task VerifyCart()
    {    
        var cartPage = new CartPage(_page, _testCaseNum, _testDataPath);

        await cartPage.VerifyProducts();
    }
}