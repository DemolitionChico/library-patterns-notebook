using PatternsNotebook.Behavioral.Bridge.MenuExample.Coupons;

namespace PatternsNotebook.Behavioral.Bridge.MenuExample.Menus;

public class MeatBasedMenu: Menu
{
    public MeatBasedMenu(ICoupon coupon) : base(coupon)
    {
    }

    public override int CalculatePrice()
    {
        return 30 - Coupon.CouponValue;
    }
}