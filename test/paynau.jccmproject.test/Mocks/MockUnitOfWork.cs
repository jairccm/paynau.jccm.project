using Microsoft.EntityFrameworkCore;
using Moq;
using paynau.jccm.project.Infraestructure.Data;
using paynau.jccm.project.Infraestructure.Repositories;

namespace paynau.jccmproject.test.Mocks;

public static class MockUnitOfWork
{


    public static Mock<UnitOfWork> GetUnitOfWork()
    {
        Guid dbContextId = Guid.NewGuid();
        var options = new DbContextOptionsBuilder<PaynauDbContext>()
            .UseInMemoryDatabase(databaseName: $"PaynauDbContext-{dbContextId}")
            .Options;

        var paynauDbContextFake = new PaynauDbContext(options);
        paynauDbContextFake.Database.EnsureDeleted();
        var mockUnitOfWork = new Mock<UnitOfWork>(paynauDbContextFake);


        return mockUnitOfWork;
    }

}
