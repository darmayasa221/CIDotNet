using Ardalis.Specification;

namespace Onboard.SharedKernel.Interfaces;

// from Ardalis.Specification
public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
{
  //Task UpdateAsync(Onboard.API.Endpoints.Article.Update.Request r, CancellationToken cancellationToken);
}
