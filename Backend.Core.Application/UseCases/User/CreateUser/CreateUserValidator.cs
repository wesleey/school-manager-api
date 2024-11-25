using Backend.Core.Domain.Enums;
using FluentValidation;

namespace Backend.Core.Application.UseCases.User.CreateUser;

public sealed class CreateUserValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(100);

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(255);

        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(8)
            .MaximumLength(60);

        RuleFor(x => x.Role)
            .NotEmpty()
            .Must(BeAValidRole)
            .WithMessage($"The specified role is invalid. Valid roles are: {string.Join(", ", Enum.GetNames(typeof(Role)))}");
    }

    private bool BeAValidRole(string? role)
        => Enum.TryParse<Role>(role, true, out _);
}
