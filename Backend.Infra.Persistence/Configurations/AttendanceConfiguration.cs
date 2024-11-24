using Backend.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infra.Persistence.Configurations;

public class AttendanceConfiguration : IEntityTypeConfiguration<Attendance>
{
    public void Configure(EntityTypeBuilder<Attendance> builder)
    {
        builder.ToTable("attendance");

        builder.Property(x => x.Id)
            .HasColumnName("id");

        builder.Property(x => x.IsPresent)
            .HasColumnName("is_present")
            .HasDefaultValueSql("1")
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .HasColumnName("created_at")
            .HasColumnType("datetime")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(x => x.UpdatedAt)
            .HasColumnName("updated_at")
            .HasColumnType("datetime")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAddOrUpdate();

        builder.Property(x => x.LessonId)
            .HasColumnName("lesson_id");

        builder.Property(x => x.StudentId)
            .HasColumnName("student_id");

        builder.HasOne(x => x.Lesson).WithMany(x => x.Attendances)
            .HasConstraintName("fk_attendance_lesson_id")
            .HasForeignKey(x => x.LessonId);

        builder.HasOne(x => x.Student).WithMany(x => x.Attendances)
            .HasConstraintName("fk_attendance_student_id")
            .HasForeignKey(x => x.StudentId);

        builder.HasKey(x => x.Id).HasName("PRIMARY");
        builder.HasIndex(x => x.LessonId, "fk_attendance_lesson_idx");
        builder.HasIndex(x => x.StudentId, "fk_attendance_student_idx");
    }
}
