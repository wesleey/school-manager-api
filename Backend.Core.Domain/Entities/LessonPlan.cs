using Backend.Core.Domain.Common;

namespace Backend.Core.Domain.Entities;

public partial class LessonPlan : BaseEntity
{
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string? Objectives { get; set; }
    public string? Materials { get; set; }
    public int ClassId { get; set; }
    public int SchoolId { get; set; }
    public virtual Class Class { get; set; } = null!;
    public virtual School School { get; set; } = null!;
    public virtual Lesson? Lesson { get; set; }
}
