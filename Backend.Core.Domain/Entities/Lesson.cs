using Backend.Core.Domain.Common;

namespace Backend.Core.Domain.Entities;

public partial class Lesson : BaseEntity
{
    public string Title { get; set; } = null!;
    public string Theme { get; set; } = null!;
    public DateTime Date { get; set; }
    public int ClassId { get; set; }
    public int SchoolId { get; set; }
    public int LessonPlanId { get; set; }
    public virtual Class Class { get; set; } = null!;
    public virtual School School { get; set; } = null!;
    public virtual LessonPlan LessonPlan { get; set; } = null!;
    public virtual ICollection<Attendance> Attendances { get; set; } = [];
}
