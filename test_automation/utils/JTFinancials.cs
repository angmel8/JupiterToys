namespace JTTests;

public class JTFinancials
{
    public JTFinancials() {}

    public string CalculateSubtotal(string price, string quantity)
    {
        double totalPrice = double.Parse(price) * Int32.Parse(quantity);

        return totalPrice.ToString("####0.00");
    }
}