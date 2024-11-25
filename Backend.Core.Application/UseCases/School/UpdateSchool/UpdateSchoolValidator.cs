using FluentValidation;

namespace Backend.Core.Application.UseCases.School.UpdateSchool;

public sealed class UpdateSchoolValidator : AbstractValidator<UpdateSchoolRequest>
{
    public UpdateSchoolValidator()
    {
        RuleFor(x => x.Cnpj)
            .Matches(@"^\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}$")
            .WithMessage("CNPJ must be in the format XX.XXX.XXX/XXXX-XX")
            .When(x => !string.IsNullOrEmpty(x.Cnpj));

        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(100)
            .When(x => !string.IsNullOrEmpty(x.Name));

        RuleFor(x => x.Address)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(100)
            .When(x => !string.IsNullOrEmpty(x.Address));

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(255)
            .When(x => !string.IsNullOrEmpty(x.Email));

        RuleFor(x => x.Phone)
            .NotEmpty()
            .Matches(@"^\(\d{2}\) 9\d{4}-\d{4}$")
            .WithMessage("Phone must be in the format (XX) 9XXXX-XXXX")
            .When(x => !string.IsNullOrEmpty(x.Phone));
    }
}
