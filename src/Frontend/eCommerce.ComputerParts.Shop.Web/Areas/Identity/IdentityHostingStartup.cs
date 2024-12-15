using Microsoft.AspNetCore.Hosting;
using Microsoft.eShopWeb.Web.Areas.Identity;

[assembly: HostingStartup(typeof(IdentityHostingStartup))]

namespace Microsoft.eShopWeb.Web.Areas.Identity;

public class IdentityHostingStartup : IHostingStartup
{
    public void Configure(IWebHostBuilder builder)
    {
        builder.ConfigureServices((context, services) =>
        {
        });
    }
}
