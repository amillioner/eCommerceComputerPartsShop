using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.eShopWeb.Web.Pages.Basket;

public class BasketViewModel
{
    public int Id { get; set; }
    public List<BasketItemViewModel> Items { get; set; } = new();
    public string? BuyerId { get; set; }
    public ShippingAddress ShippingAddress { get; set; }
    public int ShippingCost { get; set; }

    public decimal Total()
    {
        return Math.Round(Items.Sum(x => x.UnitPrice * x.Quantity), 2);
    }
    public decimal GrandTotal()
    {
        var subTotal =  Math.Round(Items.Sum(x => x.UnitPrice * x.Quantity), 2);
        return subTotal + ShippingCost;
    }
}
