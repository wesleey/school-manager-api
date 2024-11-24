using Backend.Core.Domain.Common;

namespace Backend.Core.Domain.Entities;

public partial class Announcement : BaseEntity
{
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public int UserId { get; set; }
    public int ClassId { get; set; }
    public virtual Class Class { get; set; } = null!;
    public virtual User User { get; set; } = null!;
}
