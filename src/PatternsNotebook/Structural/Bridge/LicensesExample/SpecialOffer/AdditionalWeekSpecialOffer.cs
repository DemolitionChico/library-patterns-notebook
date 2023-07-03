namespace PatternsNotebook.Structural.Bridge.LicensesExample.SpecialOffer;

public class AdditionalWeekSpecialOffer : ISpecialOffer
{
    public DateTime? CalculateExpiryDate(DateTime? initialDateTime)
    {
        return initialDateTime is DateTime date ? date.AddDays(7) : null;
    }
}