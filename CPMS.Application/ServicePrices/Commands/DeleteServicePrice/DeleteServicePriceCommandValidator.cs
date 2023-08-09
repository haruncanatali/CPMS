using FluentValidation;

namespace CPMS.Application.ServicePrices.Commands.DeleteServicePrice;

public class DeleteServicePriceCommandValidator : AbstractValidator<DeleteServicePriceCommand>
{
    public DeleteServicePriceCommandValidator()
    {
        RuleFor(c => c.Id).NotNull()
            .WithMessage("Servis belirtilmelidir.");
    }
}