using FluentValidation;

namespace CPMS.Application.ParkPrices.Commands.UpdateParkPrice;

public class UpdateParkPriceCommandValidator : AbstractValidator<UpdateParkPriceCommand>
{
    public UpdateParkPriceCommandValidator()
    {
        RuleFor(c => c.Id).NotNull()
            .WithMessage("Park ücreti belirtilmelidir.");
        RuleFor(c => c.VehicleType).NotNull()
            .WithMessage("Araç tipi seçilmelidir.");
        RuleFor(c => c.Price).NotNull()
            .WithMessage("Fiyat boş olmamalıdır.");
        RuleFor(c => c.CompanyId).NotNull()
            .WithMessage("Şirket belirtilmelidir.");
    }
}