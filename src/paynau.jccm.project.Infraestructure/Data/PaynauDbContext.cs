using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using paynau.jccm.project.Entities.Entities;

namespace paynau.jccm.project.Infraestructure.Data;

public partial class PaynauDbContext : DbContext
{
    public PaynauDbContext()
    {
    }

    public PaynauDbContext(DbContextOptions<PaynauDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Person> People { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

}
