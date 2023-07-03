namespace PatternsNotebook.Structural.Bridge.LicensesExample.Discount;

public class NoDiscount: IDiscount
{
    public int GetDiscountPercentage() => 0;
}