using PatternsNotebook.Structural.Bridge.MenuExample.Coupons;

namespace PatternsNotebook.Structural.Bridge.MenuExample.Menus;

public abstract class Menu
{
    protected ICoupon Coupon { get; init; }

    protected Menu(ICoupon coupon)
    {
        Coupon = coupon;
    }
    
    public abstract int CalculatePrice();
}