namespace PatternsNotebook.Behavioral.NullObject.BaseClassExample;

class Pl12PercentTax : TaxCalculator
{
    public override decimal GetTaxValue(decimal income, decimal expenses)
    {
        return income * .12m;
    }
}