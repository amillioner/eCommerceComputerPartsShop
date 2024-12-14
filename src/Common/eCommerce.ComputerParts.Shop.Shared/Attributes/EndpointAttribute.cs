using System;

namespace eCommerce.ComputerParts.Shop.Shared.Attributes;

public class EndpointAttribute : Attribute
{
    public string Name { get; set; }
}
