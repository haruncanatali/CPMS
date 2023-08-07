using FluentValidation;

namespace CPMS.Application.Companies.Commands.CreateCompany;

public class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
{
    public CreateCompanyCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty()
            .WithMessage("Firma adı girilmelidir.");
    }
}