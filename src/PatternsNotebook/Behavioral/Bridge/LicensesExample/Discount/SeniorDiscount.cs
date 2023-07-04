namespace PatternsNotebook.Behavioral.Bridge.LicensesExample.Discount;

public class SeniorDiscount : IDiscount
{
    public int GetDiscountPercentage() => 20;
}