using FluentValidation;

namespace CPMS.Application.Brands.Commands.UpdateBrand;

public class UpdateBrandCommandValidator : AbstractValidator<UpdateBrandCommand>
{
    public UpdateBrandCommandValidator()
    {
        RuleFor(c => c.Id).NotNull()
            .WithMessage("Marka belirtilmelidir.");
        RuleFor(c => c.Name).NotEmpty()
            .WithMessage("Marka adı girilmelidir.");
    }
}