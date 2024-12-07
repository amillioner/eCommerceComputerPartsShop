using System.Reflection;
using eCommerce.ComputerParts.Shop.Core.Entities;
using eCommerce.ComputerParts.Shop.Core.Entities.BasketAggregate;
using eCommerce.ComputerParts.Shop.Core.Entities.OrderAggregate;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.ComputerParts.Shop.Infrastructure.Data;

public class CatalogContext : DbContext
{
#pragma warning disable CS8618 // Required by Entity Framework
    public CatalogContext(DbContextOptions<CatalogContext> options) : base(options) { }

    public DbSet<Basket> Baskets { get; set; }
    public DbSet<CatalogItem> CatalogItems { get; set; }
    public DbSet<CatalogBrand> CatalogBrands { get; set; }
    public DbSet<CatalogType> CatalogTypes { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<BasketItem> BasketItems { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
