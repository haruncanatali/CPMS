using FluentValidation;

namespace CPMS.Application.ParkingLots.Commands.UpdateParkingLot;

public class UpdateParkingLotCommandValidator : AbstractValidator<UpdateParkingLotCommand>
{
    public UpdateParkingLotCommandValidator()
    {
        RuleFor(c => c.Id).NotNull()
            .WithMessage("Park alanı belirtilmelidir.");
        RuleFor(c => c.Name).NotEmpty()
            .WithMessage("Park alanının adı boş geçilmemelidir.");
        RuleFor(c => c.VehicleType).NotNull()
            .WithMessage("Araç tipi belirtilmelidir.");
        RuleFor(c => c.CompanyId).NotNull()
            .WithMessage("Şirket belirtilmelidir.");
    }
}