using Backend.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infra.Persistence.Context;

public partial class AppDbContext : DbContext
{
    public AppDbContext() { }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("server=localhost,3306;database=localdb;user=root;password=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.40-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }

    public virtual DbSet<Activity> Activities { get; set; } = null!;
    public virtual DbSet<Announcement> Announcements { get; set; } = null!;
    public virtual DbSet<Attendance> Attendances { get; set; } = null!;
    public virtual DbSet<Class> Classes { get; set; } = null!;
    public virtual DbSet<Lesson> Lessons { get; set; } = null!;
    public virtual DbSet<LessonPlan> LessonPlans { get; set; } = null!;
    public virtual DbSet<School> Schools { get; set; } = null!;
    public virtual DbSet<Student> Students { get; set; } = null!;
    public virtual DbSet<StudentActivity> StudentActivities { get; set; } = null!;
    public virtual DbSet<StudentPerformance> StudentPerformances { get; set; } = null!;
    public virtual DbSet<User> Users { get; set; } = null!;
}
