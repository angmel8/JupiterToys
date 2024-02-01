using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace JTTests;

public class JTFeedback : PageTest
{
    private readonly IPage _page;
    private readonly string _testCaseNum;
    private readonly string _testDataPath;

    public JTFeedback(IPage page, string testCaseNum, string testDataPath)
    {
        _page = page;
        _testCaseNum = testCaseNum;
        _testDataPath = testDataPath;
    }

    public async Task Submit()
    {    
        var contactPage = new ContactPage(_page, _testCaseNum, _testDataPath);
        await contactPage.EnterForename();
        await contactPage.EnterSurname();
        await contactPage.EnterEmail();
        await contactPage.EnterTelephone();
        await contactPage.EnterMessage();

        await contactPage.Submit();
    }

    public async Task AttemptToSubmit()
    {    
        var contactPage = new ContactPage(_page, _testCaseNum, _testDataPath);
        await contactPage.EnterForename();
        await contactPage.EnterSurname();
        await contactPage.EnterEmail();
        await contactPage.EnterTelephone();
        await contactPage.EnterMessage();

        await contactPage.AttemptToSubmit();
    }
}