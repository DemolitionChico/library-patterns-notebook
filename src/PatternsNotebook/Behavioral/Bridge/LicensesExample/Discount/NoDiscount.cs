namespace PatternsNotebook.Behavioral.Bridge.LicensesExample.Discount;

public class NoDiscount: IDiscount
{
    public int GetDiscountPercentage() => 0;
}