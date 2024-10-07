using AutoFixture;
using paynau.jccm.project.Entities.Entities;
using paynau.jccm.project.Infraestructure.Data;

namespace paynau.jccmproject.test.Mocks;

public static class MockPersonRepository
{
    public static void AddDataPersonRepository(PaynauDbContext paynauDbContextFake)
    {
        var fixture = new Fixture();
        fixture.Behaviors.Add(new OmitOnRecursionBehavior());

        fixture.Register<DateOnly>(() => new DateOnly(1990, 1, 1));

        var people = fixture.CreateMany<Person>().ToList();

        people.Add(fixture.Build<Person>()
           .With(tr => tr.Id, 8001)
           .With(tr => tr.DateOfBirth, new DateOnly(2000,01,01))
           .With(tr => tr.CreatedDate, DateTime.Now)
           .With(p => p.FirstName, "John")
           .With(p => p.LastName, "Doe")
           .Create()
       );

        paynauDbContextFake.People!.AddRange(people);
        paynauDbContextFake.SaveChanges();

    }
}
