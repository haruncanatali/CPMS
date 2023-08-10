using FluentValidation;

namespace CPMS.Application.ParkingServices.Commands.DeleteParkingService;

public class DeleteParkingServiceCommandValidator : AbstractValidator<DeleteParkingServiceCommand>
{
    public DeleteParkingServiceCommandValidator()
    {
        RuleFor(c => c.Id).NotNull()
            .WithMessage("Silinecek park hizmeti seçilmelidir.");
    }
}