using Backend.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infra.Persistence.Configurations;

public class AnnouncementConfiguration : IEntityTypeConfiguration<Announcement>
{
    public void Configure(EntityTypeBuilder<Announcement> builder)
    {
        builder.ToTable("announcement");

        builder.Property(x => x.Id)
            .HasColumnName("id");

        builder.Property(x => x.Title)
            .HasColumnName("title")
            .HasMaxLength(100);

        builder.Property(x => x.Content)
            .HasColumnName("content")
            .HasColumnType("text");

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

        builder.HasOne(x => x.Class).WithMany(x => x.Announcements)
            .HasConstraintName("fk_announcement_class_id")
            .HasForeignKey(x => x.ClassId);

        builder.HasOne(x => x.User).WithMany(x => x.Announcements)
            .HasConstraintName("fk_announcement_user_id")
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.ClientSetNull);

        builder.HasKey(x => x.Id).HasName("PRIMARY");
        builder.HasIndex(x => x.ClassId, "fk_announcement_class_idx");
        builder.HasIndex(x => x.UserId, "fk_announcement_user_idx");
    }
}
