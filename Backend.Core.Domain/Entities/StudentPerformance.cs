using Backend.Core.Domain.Common;

namespace Backend.Core.Domain.Entities;

public partial class StudentPerformance : BaseEntity
{
    public decimal AverageGrade { get; set; }
    public int AttendanceCount { get; set; }
    public decimal PercentageCorrect { get; set; }
    public decimal AttendancePercentage { get; set; }
    public int TasksSubmitted { get; set; }
    public int TasksNotSubmitted { get; set; }
    public int StudentId { get; set; }
    public virtual Student Student { get; set; } = null!;
}
