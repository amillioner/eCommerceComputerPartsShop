using Ardalis.Specification;

namespace eCommerce.ComputerParts.Shop.Core.Interfaces;

public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
{
}
