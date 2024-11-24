using Backend.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infra.Persistence.Configurations;

public class StudentActivityConfiguration : IEntityTypeConfiguration<StudentActivity>
{
    public void Configure(EntityTypeBuilder<StudentActivity> builder)
    {
        builder.ToTable("student_activity");

        builder.Property(x => x.Id)
            .HasColumnName("id");

        builder.Property(x => x.Note)
            .HasColumnName("note")
            .HasPrecision(4, 2);

        builder.Property(x => x.WasSubmitted)
            .HasColumnName("was_submitted");

        builder.Property(x => x.SubmissionDate)
            .HasColumnName("submission_date")
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

        builder.Property(x => x.StudentId)
            .HasColumnName("student_id");

        builder.Property(x => x.ActivityId)
            .HasColumnName("activity_id");

        builder.HasOne(x => x.Student).WithMany(x => x.StudentActivities)
            .HasConstraintName("fk_student_activity_student_id")
            .HasForeignKey(x => x.StudentId);

        builder.HasOne(x => x.Activity).WithMany(x => x.StudentActivities)
            .HasConstraintName("fk_student_activity_activity_id")
            .HasForeignKey(x => x.ActivityId);

        builder.HasKey(x => x.Id).HasName("PRIMARY");
        builder.HasIndex(x => x.StudentId, "fk_student_activity_student_idx");
        builder.HasIndex(x => x.ActivityId, "fk_student_activity_activity_idx");
    }
}
