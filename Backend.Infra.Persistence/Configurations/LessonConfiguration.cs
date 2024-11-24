using Backend.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infra.Persistence.Configurations;

public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.ToTable("lesson");

        builder.Property(x => x.Id)
            .HasColumnName("id");

        builder.Property(x => x.Title)
            .HasColumnName("title")
            .HasMaxLength(100);

        builder.Property(x => x.Theme)
            .HasColumnName("theme")
            .HasMaxLength(100);

        builder.Property(x => x.Date)
            .HasColumnName("date")
            .HasColumnType("datetime");

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

        builder.Property(x => x.LessonPlanId)
            .HasColumnName("lesson_plan_id");

        builder.HasOne(x => x.School).WithMany(x => x.Lessons)
            .HasConstraintName("fk_lesson_school_id")
            .HasForeignKey(x => x.SchoolId);

        builder.HasOne(x => x.Class).WithMany(x => x.Lessons)
            .HasConstraintName("fk_lesson_class_id")
            .HasForeignKey(x => x.ClassId);

        builder.HasOne(x => x.LessonPlan).WithOne(x => x.Lesson)
            .HasConstraintName("fk_lesson_lesson_plan_id")
            .HasForeignKey<Lesson>(x => x.LessonPlanId)
            .OnDelete(DeleteBehavior.ClientSetNull);

        builder.HasKey(x => x.Id).HasName("PRIMARY");
        builder.HasIndex(x => x.SchoolId, "fk_lesson_school_idx");
        builder.HasIndex(x => x.ClassId, "fk_lesson_class_idx");
        builder.HasIndex(x => x.LessonPlanId, "fk_lesson_lesson_plan_idx").IsUnique();
    }
}
