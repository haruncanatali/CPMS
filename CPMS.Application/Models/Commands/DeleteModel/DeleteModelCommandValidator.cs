using FluentValidation;

namespace CPMS.Application.Models.Commands.DeleteModel;

public class DeleteModelCommandValidator : AbstractValidator<DeleteModelCommand>
{
    public DeleteModelCommandValidator()
    {
        RuleFor(c => c.Id).NotNull()
            .WithMessage("Model belirtilmelidir.");
    }
}