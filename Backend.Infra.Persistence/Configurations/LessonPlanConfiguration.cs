using Backend.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infra.Persistence.Configurations;

public class LessonPlanConfiguration : IEntityTypeConfiguration<LessonPlan>
{
    public void Configure(EntityTypeBuilder<LessonPlan> builder)
    {
        builder.ToTable("lesson_plan");

        builder.Property(x => x.Id)
            .HasColumnName("id");

        builder.Property(x => x.Title)
            .HasColumnName("title")
            .HasMaxLength(100);

        builder.Property(x => x.Description)
            .HasColumnName("description")
            .HasColumnType("text");

        builder.Property(x => x.Objectives)
            .HasColumnName("objectives")
            .HasColumnType("text");

        builder.Property(x => x.Materials)
            .HasColumnName("materials")
            .HasColumnType("text");

        builder.Property(x => x.CreatedAt)
            .HasColumnName("created_at")
            .HasColumnType("datetime")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(x => x.UpdatedAt)
            .HasColumnName("updated_at")
            .HasColumnType("datetime")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAddOrUpdate();

        builder.Property(x => x.ClassId)
            .HasColumnName("class_id");

        builder.Property(x => x.SchoolId)
            .HasColumnName("school_id");

        builder.HasOne(x => x.School).WithMany(x => x.LessonPlans)
            .HasConstraintName("fk_lesson_plan_school_id")
            .HasForeignKey(x => x.SchoolId);

        builder.HasOne(x => x.Class).WithMany(x => x.LessonPlans)
            .HasConstraintName("fk_lesson_plan_class_id")
            .HasForeignKey(x => x.ClassId);

        builder.HasKey(x => x.Id).HasName("PRIMARY");
        builder.HasIndex(x => x.SchoolId, "fk_lesson_plan_school_idx");
        builder.HasIndex(x => x.ClassId, "fk_lesson_plan_class_idx");
    }
}
