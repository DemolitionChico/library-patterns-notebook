using PatternsNotebook.Structural.Bridge.LicensesExample.Discount;
using PatternsNotebook.Structural.Bridge.LicensesExample.SpecialOffer;

namespace PatternsNotebook.Structural.Bridge.LicensesExample.MovieLicense;

public class LifeLongLicense : MovieLicense
{

    public LifeLongLicense(string movieTitle, DateTime purchaseTime, IDiscount discount, ISpecialOffer specialOffer) : base(movieTitle, purchaseTime, discount, specialOffer)
    {
    }

    protected override decimal GetCoreLicensePrice()
    {
        return 20;
    }

    protected override DateTime? GetCoreLicenseExpiryDate()
    {
        return null;
    }
}