using paynau.jccm.project.Application.Contracts.Persistence;
using paynau.jccm.project.Domain.Common;
using paynau.jccm.project.Infraestructure.Data;
using System.Collections;

namespace paynau.jccm.project.Infraestructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private Hashtable _repositories;
    private readonly PaynauDbContext _context;
    public IPersonRepository _PersonRepository;

    public IPersonRepository PersonRepository => _PersonRepository ??= new PersonRepository(_context);

    public UnitOfWork(PaynauDbContext context)
    {
        _context = context;
    }

    public PaynauDbContext PaynauDbContext => _context;

    public async Task<int> Complete()
    {
        try
        {
            return await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("Err");
        }

    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel
    {
        if (_repositories == null)
        {
            _repositories = new Hashtable();
        }

        var type = typeof(TEntity).Name;

        if (!_repositories.ContainsKey(type))
        {
            var repositoryType = typeof(RepositoryBase<>);
            var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
            _repositories.Add(type, repositoryInstance);
        }

        return (IAsyncRepository<TEntity>)_repositories[type];
    }

}
