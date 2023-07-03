namespace PatternsNotebook.Structural.Bridge.LicensesExample.Discount;

public class MilitaryDiscount: IDiscount
{
    public int GetDiscountPercentage() => 10;
}