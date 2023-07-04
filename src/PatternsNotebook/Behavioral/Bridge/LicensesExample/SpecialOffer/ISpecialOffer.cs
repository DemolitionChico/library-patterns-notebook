namespace PatternsNotebook.Behavioral.Bridge.LicensesExample.SpecialOffer;

public interface ISpecialOffer
{
    DateTime? CalculateExpiryDate(DateTime? initialDateTime);
}