using PatternsNotebook.Behavioral.Bridge.LicensesExample.Discount;
using PatternsNotebook.Behavioral.Bridge.LicensesExample.SpecialOffer;

namespace PatternsNotebook.Behavioral.Bridge.LicensesExample.MovieLicense;

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