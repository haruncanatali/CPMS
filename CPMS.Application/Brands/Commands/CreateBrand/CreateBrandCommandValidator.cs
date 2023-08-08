using FluentValidation;

namespace CPMS.Application.Brands.Commands.CreateBrand;

public class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommand>
{
    public CreateBrandCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty()
            .WithMessage("Marka adı girilmelidir.");
    }    
}