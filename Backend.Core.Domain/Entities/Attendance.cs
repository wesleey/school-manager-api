using Backend.Core.Domain.Common;

namespace Backend.Core.Domain.Entities;

public partial class Attendance : BaseEntity
{
    public bool? IsPresent { get; set; }
    public int LessonId { get; set; }
    public virtual Lesson Lesson { get; set; } = null!;
    public int StudentId { get; set; }
    public virtual Student Student { get; set; } = null!;
}
