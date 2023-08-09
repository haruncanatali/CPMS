using FluentValidation;

namespace CPMS.Application.ServicePrices.Commands.UpdateServicePrice;

public class UpdateServicePriceCommandValidator : AbstractValidator<UpdateServicePriceCommand>
{
    public UpdateServicePriceCommandValidator()
    {
        RuleFor(c => c.Id).NotNull()
            .WithMessage("Servis seçilmelidir.");
        RuleFor(c => c.Name).NotEmpty()
            .WithMessage("Servis adı boş olamaz.");
        RuleFor(c => c.Price).NotNull()
            .WithMessage("Servis ücreti boş olamaz.");
        RuleFor(c => c.CompanyId).NotNull()
            .WithMessage("Şirket belirtilmelidir.");
        RuleFor(c => c.VehicleType).NotNull()
            .WithMessage("Araç tipi seçilmelidir.");
    }
}