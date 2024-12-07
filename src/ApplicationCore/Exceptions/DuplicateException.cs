using System;

namespace eCommerce.ComputerParts.Shop.Core.Exceptions;

public class DuplicateException : Exception
{
    public DuplicateException(string message) : base(message)
    {

    }

}
