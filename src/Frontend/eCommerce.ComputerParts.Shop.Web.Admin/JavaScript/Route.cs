﻿using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace eCommerce.ComputerParts.Shop.Web.Admin.JavaScript;

public class Route
{
    private readonly IJSRuntime _jsRuntime;

    public Route(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task RouteOutside(string path)
    {
        await _jsRuntime.InvokeAsync<string>(JSInteropConstants.RouteOutside, path);
    }
}
