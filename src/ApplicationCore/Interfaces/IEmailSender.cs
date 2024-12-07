using System.Threading.Tasks;

namespace eCommerce.ComputerParts.Shop.Core.Interfaces;

public interface IEmailSender
{
    Task SendEmailAsync(string email, string subject, string message);
}
