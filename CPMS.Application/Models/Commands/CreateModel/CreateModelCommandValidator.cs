using FluentValidation;

namespace CPMS.Application.Models.Commands.CreateModel;

public class CreateModelCommandValidator : AbstractValidator<CreateModelCommand>
{
    public CreateModelCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty()
            .WithMessage("Model adı girilmelidir.");
        RuleFor(c => c.BrandId).NotNull()
            .WithMessage("Marka seçilmelidir.");
    }
}