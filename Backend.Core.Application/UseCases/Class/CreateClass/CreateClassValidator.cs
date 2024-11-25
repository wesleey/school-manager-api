using Backend.Core.Domain.Enums;
using FluentValidation;

namespace Backend.Core.Application.UseCases.Class.CreateClass;

public sealed class CreateClassValidator : AbstractValidator<CreateClassRequest>
{
    public CreateClassValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(100);

        RuleFor(x => x.Shift)
            .NotEmpty()
            .Must(BeAValidShift)
            .WithMessage($"The specified shift is invalid. Valid shifts are: {string.Join(", ", Enum.GetNames(typeof(Shift)))}");

        RuleFor(x => x.AcademicYear)
            .NotEmpty()
            .MinimumLength(4)
            .MaximumLength(6);
    }

    private bool BeAValidShift(string? shift)
        => Enum.TryParse<Shift>(shift, true, out _);
}
