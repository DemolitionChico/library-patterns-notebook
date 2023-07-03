namespace PatternsNotebook.Structural.Bridge.LicensesExample.SpecialOffer;

public class NoSpecialOffer : ISpecialOffer
{
    public DateTime? CalculateExpiryDate(DateTime? initialDateTime)
    {
        return initialDateTime;
    }
}