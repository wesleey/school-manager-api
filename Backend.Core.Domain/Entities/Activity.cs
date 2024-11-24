using Backend.Core.Domain.Common;

namespace Backend.Core.Domain.Entities;

public partial class Activity : BaseEntity
{
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime DueDate { get; set; }
    public int ClassId { get; set; }
    public virtual Class Class { get; set; } = null!;
    public int UserId { get; set; }
    public virtual User User { get; set; } = null!;
    public virtual ICollection<StudentActivity> StudentActivities { get; set; } = [];
}
