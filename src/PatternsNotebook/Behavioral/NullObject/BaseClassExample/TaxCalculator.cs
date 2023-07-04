namespace PatternsNotebook.Behavioral.NullObject.BaseClassExample;

public abstract class TaxCalculator
{
    public static TaxCalculator Default { get; } = new NoTax();
    public abstract decimal GetTaxValue(decimal income, decimal expenses);
}