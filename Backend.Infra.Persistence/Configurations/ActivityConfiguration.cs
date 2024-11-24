using Backend.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infra.Persistence.Configurations;

public class ActivityConfiguration : IEntityTypeConfiguration<Activity>
{
    public void Configure(EntityTypeBuilder<Activity> builder)
    {
        builder.ToTable("activity");

        builder.Property(x => x.Id)
            .HasColumnName("id");

        builder.Property(x => x.Title)
            .HasColumnName("title")
            .HasMaxLength(100);

        builder.Property(x => x.Description)
            .HasColumnName("description")
            .HasColumnType("text");

        builder.Property(x => x.DueDate)
            .HasColumnName("due_date")
            .HasColumnType("datetime");

        builder.Property(x => x.CreatedAt)
             .HasColumnName("created_at")
             .HasColumnType("datetime")
             .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(x => x.UpdatedAt)
            .ValueGeneratedOnAddOrUpdate()
            .HasColumnName("updated_at")
            .HasColumnType("datetime")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(x => x.ClassId)
            .HasColumnName("class_id");

        builder.Property(x => x.UserId)
            .HasColumnName("user_id");

        builder.HasOne(x => x.Class).WithMany(x => x.Activities)
            .HasConstraintName("fk_activity_class_id")
            .HasForeignKey(x => x.ClassId);

        builder.HasOne(x => x.User).WithMany(x => x.Activities)
            .HasConstraintName("fk_activity_user_id")
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.ClientSetNull);

        builder.HasKey(x => x.Id).HasName("PRIMARY");
        builder.HasIndex(x => x.ClassId, "fk_activity_class_idx");
        builder.HasIndex(x => x.UserId, "fk_activity_user_idx");
    }
}
