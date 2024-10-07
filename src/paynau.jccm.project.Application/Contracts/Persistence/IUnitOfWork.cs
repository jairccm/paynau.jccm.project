using paynau.jccm.project.Domain.Common;

namespace paynau.jccm.project.Application.Contracts.Persistence;

public interface IUnitOfWork : IDisposable
{

    IPersonRepository PersonRepository { get; }
    IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel;
    Task<int> Complete();
}
