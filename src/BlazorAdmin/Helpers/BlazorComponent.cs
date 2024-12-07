﻿using Microsoft.AspNetCore.Components;

namespace eCommerce.ComputerParts.Shop.Web.Admin.Helpers;

public class BlazorComponent : ComponentBase
{
    private readonly RefreshBroadcast _refresh = RefreshBroadcast.Instance;

    protected override void OnInitialized()
    {
        _refresh.RefreshRequested += DoRefresh;
        base.OnInitialized();
    }

    public void CallRequestRefresh()
    {
        _refresh.CallRequestRefresh();
    }

    private void DoRefresh()
    {
        StateHasChanged();
    }

}
