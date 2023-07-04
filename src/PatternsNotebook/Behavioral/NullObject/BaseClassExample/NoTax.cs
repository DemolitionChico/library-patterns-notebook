namespace PatternsNotebook.Behavioral.NullObject.BaseClassExample;

class NoTax : TaxCalculator
{
    public override decimal GetTaxValue(decimal income, decimal expenses)
    {
        return 0;
    }
}