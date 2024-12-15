using Microsoft.AspNetCore.Mvc;

namespace Microsoft.eShopWeb.Web.Extensions;

public static class UrlHelperExtensions
{
    public static string? EmailConfirmationLink(this IUrlHelper urlHelper, string userId, string code, string scheme)
    {
        return urlHelper.Action(
            "GET",
            "ConfirmEmail",
            new { userId, code },
            scheme);
    }
}
