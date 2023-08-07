using FluentValidation;

namespace CPMS.Application.Companies.Commands.UpdateCompany;

public class UpdateCompanyCommandValidator : AbstractValidator<UpdateCompanyCommand>
{
    public UpdateCompanyCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty()
            .WithMessage("Firma adı girilmelidir.");
        RuleFor(c => c.Id).NotNull()
            .WithMessage("Firma belirtilmelidir.");
    }
}