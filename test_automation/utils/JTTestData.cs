using System.Text.Json;

namespace JTTests;

public class JTTestData
{
    private readonly string _forename;
    private readonly string _surname;
    private readonly string _email;
    private readonly string _telephone;
    private readonly string _message;
    private readonly JsonElement _products;
    private readonly string _errorMessage;

    public JTTestData(string testCaseNum, string filePath)
    {
        string dataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath);
        string dataJsonString = File.ReadAllText(dataPath);
        JsonDocument dataJsonDocument = JsonDocument.Parse(dataJsonString);
        JsonElement testCaseData = dataJsonDocument.RootElement.GetProperty(testCaseNum)[0];

        _forename = testCaseData.GetProperty("forename").ToString();
        _surname = testCaseData.GetProperty("surname").ToString();
        _email = testCaseData.GetProperty("email").ToString();
        _telephone = testCaseData.GetProperty("telephone").ToString();
        _message = testCaseData.GetProperty("message").ToString();
        _products = testCaseData.GetProperty("products");
        _errorMessage = testCaseData.GetProperty("errorMessage").ToString();
    }

    public string Forename()
    {
        return _forename;
    }

    public string Surname()
    {
        return _surname;
    }

    public string Email()
    {
        return _email;
    }

    public string Telephone()
    {
        return _telephone;
    }

    public string Message()
    {
        return _message;
    }

    public string ErrorMessage()
    {
        return _errorMessage;
    }

    public JsonElement Products()
    {
        return _products;
    }
}