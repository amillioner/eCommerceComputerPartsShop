using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using eCommerce.ComputerParts.Shop.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace eCommerce.ComputerParts.Shop.Data;

public class CatalogContextSeed
{
    public static async Task SeedAsync(CatalogContext catalogContext,
        ILogger logger,
        int retry = 0)
    {
        var retryForAvailability = retry;
        try
        {
            if (catalogContext.Database.IsSqlServer())
            {
                catalogContext.Database.Migrate();
            }

            if (!await catalogContext.CatalogBrands.AnyAsync())
            {
                await catalogContext.CatalogBrands.AddRangeAsync(
                    GetPreconfiguredCatalogBrands());

                await catalogContext.SaveChangesAsync();
            }

            if (!await catalogContext.CatalogTypes.AnyAsync())
            {
                await catalogContext.CatalogTypes.AddRangeAsync(
                    GetPreconfiguredCatalogTypes());

                await catalogContext.SaveChangesAsync();
            }

            if (!await catalogContext.CatalogItems.AnyAsync())
            {
                await catalogContext.CatalogItems.AddRangeAsync(
                    GetPreconfiguredItems());

                await catalogContext.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            if (retryForAvailability >= 10) throw;

            retryForAvailability++;

            logger.LogError(ex.Message);
            await SeedAsync(catalogContext, logger, retryForAvailability);
            throw;
        }
    }

    static IEnumerable<CatalogBrand> GetPreconfiguredCatalogBrands()
    {
        return new List<CatalogBrand>
            {
                new("MSI"),
                new("CORSAIR"),
                new("Intel"),
                new("Samsung"),
                new("Seagate")
            };
    }

    static IEnumerable<CatalogType> GetPreconfiguredCatalogTypes()
    {
        return new List<CatalogType>
            {
                new("Gaming"),
                new("Cooler"),
                new("Motherboard"),
                new("Ram DDR")
            };
    }

    static IEnumerable<CatalogItem> GetPreconfiguredItems()
    {
        return new List<CatalogItem>
            {
                new(2,2, "Seagate BarraCuda NE-ST8000DM004 8TB 5400 RPM 256MB Cache SATA 6.0Gb/s 3.5\" Internal Hard Drive Bare Drive", "Seagate BarraCuda NE-ST8000DM004 8TB 5400 RPM 256MB Cache SATA 6.0Gb/s 3.5\" Internal Hard Drive Bare Drive", 190.5M,  "https://c1.neweggimages.com/productimage/nb1280/22-183-793-V06.jpg"),
                new(1,2, "MSI Ventus GeForce RTX 4060", "MSI Ventus GeForce RTX 4060", 1800.50M, "https://c1.neweggimages.com/productimage/nb1280/14-137-804-11.jpg"),
                new(2,5, "MSI MAG B650 TOMAHAWK WIFI AM5 AMD B650 SATA 6Gb/s DDR5 Ryzen 7000 ATX Motherboard", "MSI MAG B650 TOMAHAWK WIFI AM5 AMD B650 SATA 6Gb/s DDR5 Ryzen 7000 ATX Motherboard", 458,  "https://c1.neweggimages.com/productimage/nb1280/13-144-557-08.jpg"),
                new(2,2, "CORSAIR iCUE H150i ELITE CAPELLIX XT Liquid CPU Cooler - AF120 RGB ELITE Fans - 360mm Radiator", "CORSAIR iCUE H150i ELITE CAPELLIX XT Liquid CPU Cooler - AF120 RGB ELITE Fans - 360mm Radiator", 123, "https://c1.neweggimages.com/productimage/nb1280/35-181-332-01.png"),
                new(3,5, "G.SKILL Flare X Series 64GB (2 x 32GB) 288-Pin PC RAM DDR5 6000", "G.SKILL Flare X Series 64GB (2 x 32GB) 288-Pin PC RAM DDR5 6000", 8.5M, "https://c1.neweggimages.com/productimage/nb1280/20-374-419-07.png"),
                new(2,2, "Cooler Master Hyper", "Cooler Master Hyper", 147, "https://c1.neweggimages.com/productimage/nb1280/35-103-364-01.png"),
                new(2,5, "Intel Core Ultra 7 265K", "Intel Core Ultra 7 265K",  120, "https://c1.neweggimages.com/productimage/nb1280/19-118-506-06.jpg"),
                new(2,5, "SAMSUNG 990 EVO PLUS SSD 4TB", "SAMSUNG 990 EVO PLUS SSD 4TB", 90.5M, "https://c1.neweggimages.com/productimage/nb1280/20-147-901-02.jpg"),
                new(1,5, "CRUA 30\" Curved Gaming Monitor", "CRUA 30\" Curved Gaming Monitor", 174, "https://c1.neweggimages.com/productimage/nb1280/BSK6S24050604FO3852.jpg"),
                new(3,2, "ABS Cyclone Aqua Gaming PC", "ABS Cyclone Aqua Gaming PC", 979, "https://c1.neweggimages.com/productimage/nb1280/83-360-497-01.jpg"),
                new(3,2, "AMD Ryzen 9 7950X", "AMD Ryzen 9 7950X", 496.5M, "https://c1.neweggimages.com/productimage/nb1280/19-113-771-09.jpg"),
                new(2,5, "GameSir G8+ Bluetooth Wireless", "GameSir G8+ Bluetooth Wireless", 79, "https://c1.neweggimages.com/productimage/nb1280/A9U6S2410220IBL4A94.jpg")
            };
    }
}
