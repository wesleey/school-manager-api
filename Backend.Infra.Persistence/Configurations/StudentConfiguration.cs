using Backend.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infra.Persistence.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("student");

        builder.Property(x => x.Id)
            .HasColumnName("id");

        builder.Property(x => x.Name)
            .HasColumnName("name")
            .HasMaxLength(100);

        builder.Property(x => x.Enrollment)
            .HasColumnName("enrollment")
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

        builder.Property(x => x.SchoolId)
            .HasColumnName("school_id");

        builder.Property(x => x.ClassId)
            .HasColumnName("class_id");

        builder.HasOne(x => x.Class).WithMany(x => x.Students)
            .HasConstraintName("fk_student_class_id")
            .HasForeignKey(x => x.ClassId);

        builder.HasOne(x => x.School).WithMany(x => x.Students)
            .HasConstraintName("fk_student_school_id")
            .HasForeignKey(x => x.SchoolId);

        builder.HasKey(x => x.Id).HasName("PRIMARY");
        builder.HasIndex(x => x.Enrollment, "enrollment_student_unique").IsUnique();
        builder.HasIndex(x => x.SchoolId, "fk_student_school_idx");
        builder.HasIndex(x => x.ClassId, "fk_student_class_idx");
    }
}
