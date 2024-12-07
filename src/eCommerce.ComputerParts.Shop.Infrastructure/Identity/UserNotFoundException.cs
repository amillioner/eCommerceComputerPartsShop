using System;

namespace eCommerce.ComputerParts.Shop.Infrastructure.Identity;

public class UserNotFoundException : Exception
{
    public UserNotFoundException(string userName) : base($"No user found with username: {userName}")
    {
    }
}
