using PatternsNotebook.Behavioral.Bridge.LicensesExample.Discount;
using PatternsNotebook.Behavioral.Bridge.LicensesExample.MovieLicense;
using PatternsNotebook.Behavioral.Bridge.LicensesExample.SpecialOffer;

namespace PatternsNotebook.Behavioral.Bridge.LicensesExample;

public class BridgeLicensesExample: ExampleBase
{
    protected override void Execute()
    {
        Console.WriteLine("Type a discount type (military/senior)");
        var selectedDiscount = Console.ReadLine();
        IDiscount discount = selectedDiscount switch
        {
            "military" => new MilitaryDiscount(),
            "senior" => new SeniorDiscount(),
            _ => new NoDiscount()
        };
        Console.WriteLine("Type an offer type (add-week/lifelong)");
        var selectedOffer = Console.ReadLine();
        ISpecialOffer offer = selectedOffer switch
        {
            "add-week" => new AdditionalWeekSpecialOffer(),
            "lifelong" => new LifeLongSpecialOffer(),
            _ => new NoSpecialOffer()
        };
        var lifeLongLicense = new LifeLongLicense("Movie title", DateTime.Now, discount, offer);
        var twoDaysLicense = new TwoDaysMovieLicense("Movie title", DateTime.Now, discount, offer);
        
        Console.Clear();
        Console.WriteLine("-----------------------");
        var lifelongExpiry = lifeLongLicense.GetExpiryDate();
        Console.WriteLine($"Lifelong license for ${lifeLongLicense.MovieTitle} expires {(lifelongExpiry.HasValue ? lifelongExpiry.ToString() : "never")} costs {lifeLongLicense.GetPrice()}");
        var twodaysExpiry = twoDaysLicense.GetExpiryDate();
        Console.WriteLine($"Two days license for ${twoDaysLicense.MovieTitle} expires {(twodaysExpiry.HasValue ? twodaysExpiry.ToString() : "never")} costs {twoDaysLicense.GetPrice()}");
        Console.WriteLine("-----------------------");
    }
}