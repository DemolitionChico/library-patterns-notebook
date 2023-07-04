namespace PatternsNotebook.Behavioral.Bridge.LicensesExample.Discount;

public class MilitaryDiscount: IDiscount
{
    public int GetDiscountPercentage() => 10;
}