using System;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using eCommerce.ComputerParts.Shop.Core.Interfaces;
using eCommerce.ComputerParts.Shop.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.eShopWeb.Web.Interfaces;

namespace Microsoft.eShopWeb.Web.Pages.Basket;

[Authorize]
public class CheckoutDeliveryModel : PageModel
{
    private readonly IBasketService _basketService;
    private readonly IBasketViewModelService _basketViewModelService;
    private readonly IAppLogger<CheckoutModel> _logger;
    private readonly IOrderService _orderService;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private string? _username;

    public CheckoutDeliveryModel(IBasketService basketService,
        IBasketViewModelService basketViewModelService,
        SignInManager<ApplicationUser> signInManager,
        IOrderService orderService,
        IAppLogger<CheckoutModel> logger)
    {
        _basketService = basketService;
        _signInManager = signInManager;
        _orderService = orderService;
        _basketViewModelService = basketViewModelService;
        _logger = logger;
    }

    public BasketViewModel BasketModel { get; set; } = new();
    public object SelectedDeliveryOption { get; set; }

    public async Task OnGet()
    {
        await SetBasketModelAsync();
    }

    private async Task SetBasketModelAsync()
    {
        Guard.Against.Null(User?.Identity?.Name, nameof(User.Identity.Name));
        if (_signInManager.IsSignedIn(HttpContext.User))
        {
            BasketModel = await _basketViewModelService.GetOrCreateBasketForUser(User.Identity.Name);
        }
        else
        {
            GetOrSetBasketCookieAndUserName();
            BasketModel = await _basketViewModelService.GetOrCreateBasketForUser(_username!);
        }
    }

    private void GetOrSetBasketCookieAndUserName()
    {
        if (Request.Cookies.ContainsKey(Constants.BASKET_COOKIENAME))
        {
            _username = Request.Cookies[Constants.BASKET_COOKIENAME];
        }

        if (_username != null)
        {
            return;
        }

        _username = Guid.NewGuid().ToString();
        var cookieOptions = new CookieOptions { Expires = DateTime.Today.AddYears(10) };
        Response.Cookies.Append(Constants.BASKET_COOKIENAME, _username, cookieOptions);
    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid)
        {
            // Process form submission (e.g., save address to database)
            TempData["Message"] = "Address saved as default!";
            return Page();
        }

        return Page();
    }
}
