namespace PatternsNotebook.Behavioral.NullObject.BaseClassExample;

class Pl19PercentTax : TaxCalculator
{
    public override decimal GetTaxValue(decimal income, decimal expenses)
    {
        return (income - expenses) * .19m;
    }
}