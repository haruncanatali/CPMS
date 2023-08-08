using FluentValidation;

namespace CPMS.Application.Brands.Commands.DeleteBrand;

public class DeleteBrandCommandValidator : AbstractValidator<DeleteBrandCommand>
{
    public DeleteBrandCommandValidator()
    {
        RuleFor(c => c.Id).NotNull()
            .WithMessage("Marka belirtilmelidir.");
    }
}