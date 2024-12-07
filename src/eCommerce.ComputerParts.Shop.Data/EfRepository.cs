using Ardalis.Specification.EntityFrameworkCore;
using eCommerce.ComputerParts.Shop.Core.Interfaces;

namespace eCommerce.ComputerParts.Shop.Data;

public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot
{
    public EfRepository(CatalogContext dbContext) : base(dbContext)
    {
    }
}
