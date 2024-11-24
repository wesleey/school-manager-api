using Backend.Core.Domain.Common;

namespace Backend.Core.Domain.Entities;

public partial class Class : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Shift { get; set; } = null!;
    public string AcademicYear { get; set; } = null!;
    public int SchoolId { get; set; }
    public virtual School School { get; set; } = null!;
    public virtual ICollection<Activity> Activities { get; set; } = [];
    public virtual ICollection<Announcement> Announcements { get; set; } = [];
    public virtual ICollection<LessonPlan> LessonPlans { get; set; } = [];
    public virtual ICollection<Lesson> Lessons { get; set; } = [];
    public virtual ICollection<Student> Students { get; set; } = [];
}
