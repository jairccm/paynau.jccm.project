using Microsoft.Extensions.Logging;
using paynau.jccm.project.Entities.Entities;

namespace paynau.jccm.project.Infraestructure.Data;

public class PaynauDbContextSeed
{
    public static async Task SeedAsync(PaynauDbContext context, ILogger<PaynauDbContextSeed> logger)
    {
        if (!context.People!.Any())
        {
            context.People!.AddRange(GetPreconfiguredStreamer());
            await context.SaveChangesAsync();
            logger.LogInformation("Estamos insertando nuevos records al db {context}", typeof(PaynauDbContext).Name);
        }

    }

    private static IEnumerable<Person> GetPreconfiguredStreamer()
    {
        return new List<Person>
        {
            new Person { FirstName = "John", LastName = "Doe", DateOfBirth = new DateOnly(1985, 5, 15), Email = "john.doe@example.com", PhoneNumber = "123456789", CreatedDate = DateTime.Now },
            new Person { FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1990, 8, 20), Email = "jane.smith@example.com", PhoneNumber = "987654321", CreatedDate = DateTime.Now },
            new Person { FirstName = "James", LastName = "Brown", DateOfBirth = new DateOnly(1987, 12, 10), Email = "james.brown@example.com", PhoneNumber = "456123789", CreatedDate = DateTime.Now },
            new Person { FirstName = "Emily", LastName = "Davis", DateOfBirth = new DateOnly(1995, 2, 25), Email = "emily.davis@example.com", PhoneNumber = "789456123", CreatedDate = DateTime.Now },
            new Person { FirstName = "Michael", LastName = "Johnson", DateOfBirth = new DateOnly(1983, 4, 5), Email = "michael.johnson@example.com", PhoneNumber = "321654987", CreatedDate = DateTime.Now },
            new Person { FirstName = "Sarah", LastName = "Wilson", DateOfBirth = new DateOnly(1992, 7, 30), Email = "sarah.wilson@example.com", PhoneNumber = "654321789", CreatedDate = DateTime.Now },
            new Person { FirstName = "David", LastName = "Taylor", DateOfBirth = new DateOnly(1980, 9, 15), Email = "david.taylor@example.com", PhoneNumber = "159753486", CreatedDate = DateTime.Now },
            new Person { FirstName = "Emma", LastName = "Miller", DateOfBirth = new DateOnly(1997, 11, 22), Email = "emma.miller@example.com", PhoneNumber = "753159486", CreatedDate = DateTime.Now },
            new Person { FirstName = "Daniel", LastName = "Garcia", DateOfBirth = new DateOnly(1986, 1, 18), Email = "daniel.garcia@example.com", PhoneNumber = "951753486", CreatedDate = DateTime.Now },
            new Person { FirstName = "Sophia", LastName = "Martinez", DateOfBirth = new DateOnly(1993, 3, 10), Email = "sophia.martinez@example.com", PhoneNumber = "357951486", CreatedDate = DateTime.Now }
        };

    }
}
