using System;

namespace eCommerce.ComputerParts.Shop.Web.Admin.Helpers;

internal sealed class RefreshBroadcast
{
    private static readonly Lazy<RefreshBroadcast>
        Lazy =
            new Lazy<RefreshBroadcast>
                (() => new RefreshBroadcast());

    public static RefreshBroadcast Instance => Lazy.Value;

    private RefreshBroadcast()
    {
    }

    public event Action RefreshRequested;
    public void CallRequestRefresh()
    {
        RefreshRequested?.Invoke();
    }
}
