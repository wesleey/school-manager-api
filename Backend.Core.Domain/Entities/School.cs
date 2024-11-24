using Backend.Core.Domain.Common;

namespace Backend.Core.Domain.Entities;

public partial class School : BaseEntity
{
    public string Cnpj { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public virtual ICollection<Class> Classes { get; set; } = [];
    public virtual ICollection<LessonPlan> LessonPlans { get; set; } = [];
    public virtual ICollection<Lesson> Lessons { get; set; } = [];
    public virtual ICollection<Student> Students { get; set; } = [];
}
