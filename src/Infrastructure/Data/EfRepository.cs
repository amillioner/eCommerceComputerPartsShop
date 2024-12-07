﻿using Ardalis.Specification.EntityFrameworkCore;
using eCommerce.ComputerParts.Shop.Core.Interfaces;

namespace Microsoft.eShopWeb.Infrastructure.Data;

public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot
{
    public EfRepository(CatalogContext dbContext) : base(dbContext)
    {
    }
}
