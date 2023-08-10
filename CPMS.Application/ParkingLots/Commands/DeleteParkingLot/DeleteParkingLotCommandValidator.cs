using FluentValidation;

namespace CPMS.Application.ParkingLots.Commands.DeleteParkingLot;

public class DeleteParkingLotCommandValidator : AbstractValidator<DeleteParkingLotCommand>
{
    public DeleteParkingLotCommandValidator()
    {
        RuleFor(c => c.Id).NotNull()
            .WithMessage("Park alanı belirtilmelidir.");
    }
}