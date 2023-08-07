using FluentValidation;

namespace CPMS.Application.Companies.Commands.DeleteCompany;

public class DeleteCompanyCommandValidator : AbstractValidator<DeleteCompanyCommand>
{
    public DeleteCompanyCommandValidator()
    {
        RuleFor(c => c.Id).NotNull()
            .WithMessage("Firma belirtilmelidir.");
    }
}