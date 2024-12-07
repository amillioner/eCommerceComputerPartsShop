using System;

namespace eCommerce.ComputerParts.Shop.Web.Shared.Attributes;

public class EndpointAttribute : Attribute
{
    public string Name { get; set; }
}
