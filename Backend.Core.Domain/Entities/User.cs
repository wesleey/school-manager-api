using Backend.Core.Domain.Common;
using Backend.Core.Domain.Enums;

namespace Backend.Core.Domain.Entities;

public partial class User : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Role { get; set; } = null!;
    public virtual ICollection<Activity> Activities { get; set; } = new List<Activity>();
    public virtual ICollection<Announcement> Announcements { get; set; } = new List<Announcement>();
}
