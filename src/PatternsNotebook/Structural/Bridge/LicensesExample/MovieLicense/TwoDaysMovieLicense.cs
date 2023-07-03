using PatternsNotebook.Structural.Bridge.LicensesExample.Discount;
using PatternsNotebook.Structural.Bridge.LicensesExample.SpecialOffer;

namespace PatternsNotebook.Structural.Bridge.LicensesExample.MovieLicense;

public class TwoDaysMovieLicense: MovieLicense
{
    public TwoDaysMovieLicense(string movieTitle, DateTime purchaseTime, IDiscount discount, ISpecialOffer specialOffer) : base(movieTitle, purchaseTime, discount, specialOffer)
    {
    }
    
    protected override decimal GetCoreLicensePrice()
    {
        return 5;
    }

    protected override DateTime? GetCoreLicenseExpiryDate()
    {
        return _purchaseTime.AddDays(2);
    }
}