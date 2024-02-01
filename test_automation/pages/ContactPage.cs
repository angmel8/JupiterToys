using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace JTTests;

public class ContactPage : PageTest
{
    private readonly IPage _page;
    private readonly string _forename;
    private readonly string _surname;
    private readonly string _email;
    private readonly string _telephone;
    private readonly string _message;
    private readonly string _errorMessage;
    private readonly ILocator _locatorForename;
    private readonly ILocator _locatorSurname;
    private readonly ILocator _locatorEmail;
    private readonly ILocator _locatorTelephone;
    private readonly ILocator _locatorMessage;
    private readonly ILocator _locatorSubmit;
    private readonly ILocator _locatorProgressMessage;
    private readonly ILocator _locatorSuccessMessage;
    private readonly ILocator _locatorErrorMessage;

    public ContactPage(IPage page, string testCaseNum, string filePath)
    {
        JTTestData testCaseData = new JTTestData(testCaseNum, filePath);

        _forename = testCaseData.Forename();
        _surname = testCaseData.Surname();
        _email = testCaseData.Email();
        _telephone = testCaseData.Telephone();
        _message = testCaseData.Message();
        _errorMessage = testCaseData.ErrorMessage();

        _locatorForename = page.GetByPlaceholder("John", new() { Exact = true });
        _locatorSurname = page.GetByPlaceholder("Example", new() { Exact = true });
        _locatorEmail = page.GetByPlaceholder("john.example@planit.net.au");
        _locatorTelephone = page.GetByPlaceholder("1234 5678");
        _locatorMessage = page.GetByPlaceholder("Tell us about it..");
        _locatorSubmit = page.GetByRole(AriaRole.Link, new() { Name = "Submit" });
        _locatorProgressMessage = page.GetByRole(AriaRole.Heading, new() { Name = "Sending Feedback" });
        _locatorSuccessMessage = page.GetByText("Thanks ");
        _locatorErrorMessage = page.Locator("#forename-err");

        _page = page;
    }

    public async Task EnterForename()
    {
        await _locatorForename.ClickAsync();
        await _locatorForename.FillAsync(_forename);
    }

    public async Task EnterSurname()
    {
        await _locatorSurname.ClickAsync();
        await _locatorSurname.FillAsync(_surname);
    }

    public async Task EnterEmail()
    {
        await _locatorEmail.ClickAsync();
        await _locatorEmail.FillAsync(_email);
    }

    public async Task EnterTelephone()
    {
        await _locatorTelephone.ClickAsync();
        await _locatorTelephone.FillAsync(_telephone);
    }

    public async Task EnterMessage()
    {
        await _locatorMessage.ClickAsync();
        await _locatorMessage.FillAsync(_message);
    }

    public async Task Submit()
    {
        await _locatorSubmit.ClickAsync();

        await Expect(_locatorProgressMessage).ToBeVisibleAsync();
        await Expect(_locatorSuccessMessage).ToContainTextAsync("Thanks ");
    }

    public async Task AttemptToSubmit()
    {
        await _locatorSubmit.ClickAsync();

        await Expect(_locatorErrorMessage).ToContainTextAsync(_errorMessage);
    }
}