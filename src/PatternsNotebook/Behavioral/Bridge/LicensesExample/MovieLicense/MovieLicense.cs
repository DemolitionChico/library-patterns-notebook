using PatternsNotebook.Behavioral.Bridge.LicensesExample.Discount;
using PatternsNotebook.Behavioral.Bridge.LicensesExample.SpecialOffer;

namespace PatternsNotebook.Behavioral.Bridge.LicensesExample.MovieLicense;

public abstract class MovieLicense
{
    public string MovieTitle { get; init; }
    protected DateTime _purchaseTime;

    private readonly IDiscount _discount;
    private readonly ISpecialOffer _specialOffer;
    
    protected MovieLicense(string movieTitle, DateTime purchaseTime, IDiscount discount, ISpecialOffer specialOffer)
    {
        MovieTitle = movieTitle;
        _purchaseTime = purchaseTime;
        _discount = discount;
        _specialOffer = specialOffer;
    }

    public decimal GetPrice()
    {
        decimal multiplier = (100 - _discount.GetDiscountPercentage()) / 100m;
        return GetCoreLicensePrice() * multiplier;
    }

    public DateTime? GetExpiryDate()
    {
        return _specialOffer.CalculateExpiryDate(GetCoreLicenseExpiryDate());
    }

    protected abstract decimal GetCoreLicensePrice();
    protected abstract DateTime? GetCoreLicenseExpiryDate();
}