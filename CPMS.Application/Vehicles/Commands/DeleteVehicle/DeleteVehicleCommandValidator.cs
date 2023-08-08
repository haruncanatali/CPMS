using FluentValidation;

namespace CPMS.Application.Vehicles.Commands.DeleteVehicle;

public class DeleteVehicleCommandValidator : AbstractValidator<DeleteVehicleCommand>
{
    public DeleteVehicleCommandValidator()
    {
        RuleFor(c => c.Id).NotNull()
            .WithMessage("Araç belirtilmelidir.");
    }
}