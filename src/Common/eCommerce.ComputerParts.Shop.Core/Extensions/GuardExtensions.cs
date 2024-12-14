using System.Collections.Generic;
using System.Linq;
using Ardalis.GuardClauses;
using eCommerce.ComputerParts.Shop.Core.Entities.BasketAggregate;
using eCommerce.ComputerParts.Shop.Core.Exceptions;

namespace eCommerce.ComputerParts.Shop.Core.Extensions;

public static class BasketGuards
{
    public static void EmptyBasketOnCheckout(this IGuardClause guardClause, IReadOnlyCollection<BasketItem> basketItems)
    {
        if (!basketItems.Any())
            throw new EmptyBasketOnCheckoutException();
    }
}
