using Microsoft.Playwright.NUnit;
using JTTests;

public class TC_002 : PageTest
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
        await homePage.GotoContactTab();

        var feedback = new JTFeedback(page, "TC_002", testDataPath);
        await feedback.Submit();

        await jtPage.Close();

        Console.Write("TC_002: Submit feedback and validate submission message");
    }
}