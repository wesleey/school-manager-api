using Backend.Core.Domain.Common;

namespace Backend.Core.Domain.Entities;

public partial class StudentActivity : BaseEntity
{
    public decimal? Note { get; set; }
    public bool WasSubmitted { get; set; }
    public DateTime? SubmissionDate { get; set; }
    public int StudentId { get; set; }
    public int ActivityId { get; set; }
    public virtual Activity Activity { get; set; } = null!;
    public virtual Student Student { get; set; } = null!;
}
