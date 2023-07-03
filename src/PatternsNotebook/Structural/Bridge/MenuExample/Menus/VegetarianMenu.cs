using PatternsNotebook.Structural.Bridge.MenuExample.Coupons;

namespace PatternsNotebook.Structural.Bridge.MenuExample.Menus;

public class VegetarianMenu : Menu
{
    public VegetarianMenu(ICoupon coupon) : base(coupon)
    {
    }

    public override int CalculatePrice()
    {
        return 20 - Coupon.CouponValue;
    }
}