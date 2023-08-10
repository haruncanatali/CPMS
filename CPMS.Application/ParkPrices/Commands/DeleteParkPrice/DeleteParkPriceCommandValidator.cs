using FluentValidation;

namespace CPMS.Application.ParkPrices.Commands.DeleteParkPrice;

public class DeleteParkPriceCommandValidator : AbstractValidator<DeleteParkPriceCommand>
{
    public DeleteParkPriceCommandValidator()
    {
        RuleFor(c => c.Id).NotNull()
            .WithMessage("Silinecek park ücreti belirtilmelidir.");
    }
}