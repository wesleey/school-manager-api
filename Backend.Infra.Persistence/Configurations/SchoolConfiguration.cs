using Backend.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infra.Persistence.Configurations;

public class SchoolConfiguration : IEntityTypeConfiguration<School>
{
    public void Configure(EntityTypeBuilder<School> builder)
    {
        builder.ToTable("school");

        builder.Property(x => x.Id)
            .HasColumnName("id");

        builder.Property(x => x.Cnpj)
            .HasColumnName("cnpj")
            .HasMaxLength(18);

        builder.Property(x => x.Name)
            .HasColumnName("name")
            .HasMaxLength(100);

        builder.Property(x => x.Address)
            .HasColumnName("address")
            .HasMaxLength(100);

        builder.Property(x => x.Email)
            .HasColumnName("email")
            .HasMaxLength(255);

        builder.Property(x => x.Phone)
            .HasColumnName("phone")
            .HasMaxLength(25);

        builder.Property(x => x.CreatedAt)
            .HasColumnName("created_at")
            .HasColumnType("datetime")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(x => x.UpdatedAt)
            .HasColumnName("updated_at")
            .HasColumnType("datetime")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAddOrUpdate();

        builder.HasKey(x => x.Id).HasName("PRIMARY");
        builder.HasIndex(x => x.Cnpj, "cnpj_school_unique").IsUnique();
    }
}
