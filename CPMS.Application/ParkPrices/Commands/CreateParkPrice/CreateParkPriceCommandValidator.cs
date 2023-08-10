using FluentValidation;

namespace CPMS.Application.ParkPrices.Commands.CreateParkPrice;

public class CreateParkPriceCommandValidator : AbstractValidator<CreateParkPriceCommand>
{
    public CreateParkPriceCommandValidator()
    {
        RuleFor(c => c.VehicleType).NotNull()
            .WithMessage("Araç tipi seçilmelidir.");
        RuleFor(c => c.Price).NotNull()
            .WithMessage("Fiyat boş olmamalıdır.");
        RuleFor(c => c.CompanyId).NotNull()
            .WithMessage("Şirket belirtilmelidir.");
    }
}