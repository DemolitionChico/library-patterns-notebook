using PatternsNotebook.Behavioral.Bridge.MenuExample.Coupons;
using PatternsNotebook.Behavioral.Bridge.MenuExample.Menus;

namespace PatternsNotebook.Behavioral.Bridge.MenuExample;

public class BridgeMenusExample: ExampleBase
{
    protected override void Execute()
    {
        Console.WriteLine("Type a coupon type (one/two)");
        var couponType = Console.ReadLine();
        ICoupon coupon = couponType switch
        {
            "one" => new OneEuroCoupon(),
            "two" => new TwoEuroCoupon(),
            _ => new NoCoupon()
        };
        var vegeMenu = new VegetarianMenu(coupon);
        var meatMenu = new MeatBasedMenu(coupon);
        
        Console.Clear();
        Console.WriteLine("-----------------------");
        Console.WriteLine($"The cost of Vegetarian menu is {vegeMenu.CalculatePrice()} and Meat menu is {meatMenu.CalculatePrice()} with your {coupon.CouponValue}$ coupon");
        Console.WriteLine("-----------------------");
    }
}