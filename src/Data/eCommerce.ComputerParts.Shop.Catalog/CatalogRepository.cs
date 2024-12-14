using Ardalis.Specification.EntityFrameworkCore;
using eCommerce.ComputerParts.Shop.Core.Interfaces;

namespace eCommerce.ComputerParts.Shop.Catalog;

public class CatalogRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot
{
    public CatalogRepository(CatalogContext dbContext) : base(dbContext)
    {
    }
}
