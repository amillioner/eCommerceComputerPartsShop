using Ardalis.Specification;

namespace eCommerce.ComputerParts.Shop.Core.Interfaces;

public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
{
}
