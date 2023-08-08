using FluentValidation;

namespace CPMS.Application.Models.Commands.UpdateModel;

public class UpdateModelCommandValidator : AbstractValidator<UpdateModelCommand>
{
    public UpdateModelCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty()
            .WithMessage("Model adı girilmelidir.");
        RuleFor(c => c.BrandId).NotNull()
            .WithMessage("Marka seçilmelidir.");
        RuleFor(c => c.Id).NotNull()
            .WithMessage("Model belirtilmelidir.");
    }
}