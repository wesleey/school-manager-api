using FluentValidation;

namespace Backend.Core.Application.UseCases.School.CreateSchool;

public sealed class CreateSchoolValidator : AbstractValidator<CreateSchoolRequest>
{
    public CreateSchoolValidator()
    {
        RuleFor(x => x.Cnpj)
            .NotEmpty()
            .Matches(@"^\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}$")
            .WithMessage("CNPJ must be in the format XX.XXX.XXX/XXXX-XX");

        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(100);

        RuleFor(x => x.Address)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(100);

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(255);

        RuleFor(x => x.Phone)
            .NotEmpty()
            .Matches(@"^\(\d{2}\) 9\d{4}-\d{4}$")
            .WithMessage("Phone must be in the format (XX) 9XXXX-XXXX");
    }
}
