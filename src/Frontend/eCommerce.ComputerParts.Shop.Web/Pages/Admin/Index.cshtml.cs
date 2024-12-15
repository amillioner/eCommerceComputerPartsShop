﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Microsoft.eShopWeb.Web.Pages.Admin;

[Authorize(Roles = eCommerce.ComputerParts.Shop.Shared.Authorization.Constants.Roles.ADMINISTRATORS)]
public class IndexModel : PageModel
{
}
