using FluentValidation;

namespace CPMS.Application.ParkingLots.Commands.CreateParkingLot;

public class CreateParkingLotCommandValidator : AbstractValidator<CreateParkingLotCommand>
{
    public CreateParkingLotCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty()
            .WithMessage("Park alanının adı boş geçilmemelidir.");
        RuleFor(c => c.VehicleType).NotNull()
            .WithMessage("Araç tipi belirtilmelidir.");
        RuleFor(c => c.CompanyId).NotNull()
            .WithMessage("Şirket belirtilmelidir.");
    }
}