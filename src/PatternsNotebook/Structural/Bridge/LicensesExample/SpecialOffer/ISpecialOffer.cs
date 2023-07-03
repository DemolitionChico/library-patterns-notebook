namespace PatternsNotebook.Structural.Bridge.LicensesExample.SpecialOffer;

public interface ISpecialOffer
{
    DateTime? CalculateExpiryDate(DateTime? initialDateTime);
}