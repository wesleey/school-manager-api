using Backend.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infra.Persistence.Configurations;

public class StudentPerformanceConfiguration : IEntityTypeConfiguration<StudentPerformance>
{
    public void Configure(EntityTypeBuilder<StudentPerformance> builder)
    {
        builder.ToTable("student_performance");

        builder.Property(x => x.Id)
            .HasColumnName("id");

        builder.Property(x => x.AverageGrade)
            .HasColumnName("average_grade")
            .HasPrecision(10, 2);

        builder.Property(x => x.AttendanceCount)
            .HasColumnName("attendance_count");

        builder.Property(x => x.PercentageCorrect)
            .HasColumnName("percentage_correct")
            .HasPrecision(5, 2);

        builder.Property(x => x.AttendancePercentage)
            .HasColumnName("attendance_percentage")
            .HasPrecision(5, 2);

        builder.Property(x => x.TasksSubmitted)
            .HasColumnName("tasks_submitted");

        builder.Property(x => x.TasksNotSubmitted)
            .HasColumnName("tasks_not_submitted");

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

        builder.HasOne(x => x.Student).WithMany(x => x.StudentPerformances)
            .HasConstraintName("fk_student_performance_student_id")
            .HasForeignKey(x => x.StudentId);

        builder.HasKey(x => x.Id).HasName("PRIMARY");
        builder.HasIndex(x => x.StudentId, "fk_student_performance_student_idx");
    }
}
