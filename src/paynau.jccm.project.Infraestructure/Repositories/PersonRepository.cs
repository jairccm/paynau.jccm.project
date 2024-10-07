using paynau.jccm.project.Application.Contracts.Persistence;
using paynau.jccm.project.Entities.Entities;
using paynau.jccm.project.Infraestructure.Data;

namespace paynau.jccm.project.Infraestructure.Repositories;

public class PersonRepository : RepositoryBase<Person>, IPersonRepository
{
    public PersonRepository(PaynauDbContext context) : base(context)
    {
    }
}
