﻿using eCommerce.ComputerParts.Shop.Catalog;
using eCommerce.ComputerParts.Shop.Identity;
using eCommerce.ComputerParts.Shop.Service.AuthEndpoints;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace eCommerce.ComputerParts.Shop.FunctionalTests.PublicApi;

public class TestApiApplication : WebApplicationFactory<AuthenticateEndpoint>
{
    private readonly string _environment = "Testing";

    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.UseEnvironment(_environment);

        // Add mock/test services to the builder here
        builder.ConfigureServices(services =>
        {
            services.AddScoped(sp =>
            {
                // Replace SQLite with in-memory database for tests
                return new DbContextOptionsBuilder<CatalogContext>()
                .UseInMemoryDatabase("DbForPublicApi")
                .UseApplicationServiceProvider(sp)
                .Options;
            });
            services.AddScoped(sp =>
            {
                // Replace SQLite with in-memory database for tests
                return new DbContextOptionsBuilder<AppIdentityDbContext>()
                .UseInMemoryDatabase("IdentityDbForPublicApi")
                .UseApplicationServiceProvider(sp)
                .Options;
            });
        });

        return base.CreateHost(builder);
    }
}
