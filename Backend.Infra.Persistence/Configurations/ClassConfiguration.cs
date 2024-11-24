using Backend.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infra.Persistence.Configurations;

public class ClassConfiguration : IEntityTypeConfiguration<Class>
{
    public void Configure(EntityTypeBuilder<Class> builder)
    {
        builder.ToTable("class");

        builder.Property(x => x.Id)
            .HasColumnName("id");

        builder.Property(x => x.Name)
            .HasColumnName("name")
            .HasMaxLength(100);

        builder.Property(x => x.Shift)
            .HasColumnName("shift")
            .HasColumnType("enum('morning','afternoon','evening')");

        builder.Property(x => x.AcademicYear)
            .HasColumnName("academic_year")
            .HasMaxLength(6);

        builder.Property(x => x.CreatedAt)
            .HasColumnName("created_at")
            .HasColumnType("datetime")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(x => x.UpdatedAt)
            .HasColumnName("updated_at")
            .HasColumnType("datetime")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAddOrUpdate();

        builder.Property(x => x.SchoolId)
            .HasColumnName("school_id");

        builder.HasOne(x => x.School).WithMany(x => x.Classes)
            .HasConstraintName("fk_class_school_id")
            .HasForeignKey(x => x.SchoolId);

        builder.HasKey(x => x.Id).HasName("PRIMARY");
        builder.HasIndex(x => x.SchoolId, "fk_class_school_idx");
    }
}
