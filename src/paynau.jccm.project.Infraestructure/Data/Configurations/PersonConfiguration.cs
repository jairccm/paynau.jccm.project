using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using paynau.jccm.project.Entities.Entities;

namespace paynau.jccm.project.Infraestructure.Data.Configurations;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> entity)
    {

        entity.HasKey(e => e.Id).HasName("PRIMARY");

        entity.ToTable("tbl_person");

        entity.Property(e => e.Id).HasColumnName("id");
        entity.Property(e => e.CreatedDate)
            .HasColumnType("datetime")
            .HasColumnName("create_date");
        entity.Property(e => e.DateOfBirth).HasColumnName("date_of_birth");
        entity.Property(e => e.Email)
            .HasMaxLength(100)
            .HasColumnName("email");
        entity.Property(e => e.FirstName)
            .HasMaxLength(70)
            .HasColumnName("first_name");
        entity.Property(e => e.LastName)
            .HasMaxLength(100)
            .HasColumnName("last_name");
        entity.Property(e => e.PhoneNumber)
            .HasMaxLength(20)
            .HasColumnName("phone_number");

    }
}
