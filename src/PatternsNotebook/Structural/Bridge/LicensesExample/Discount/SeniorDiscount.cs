namespace PatternsNotebook.Structural.Bridge.LicensesExample.Discount;

public class SeniorDiscount : IDiscount
{
    public int GetDiscountPercentage() => 20;
}