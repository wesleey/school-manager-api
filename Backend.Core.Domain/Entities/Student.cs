using Backend.Core.Domain.Common;

namespace Backend.Core.Domain.Entities;

public partial class Student : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Enrollment { get; set; } = null!;
    public int ClassId { get; set; }
    public int SchoolId { get; set; }
    public virtual Class Class { get; set; } = null!;
    public virtual School School { get; set; } = null!;
    public virtual ICollection<Attendance> Attendances { get; set; } = [];
    public virtual ICollection<StudentActivity> StudentActivities { get; set; } = [];
    public virtual ICollection<StudentPerformance> StudentPerformances { get; set; } = [];
}
