using FluentValidation;

namespace CPMS.Application.ParkingServices.Commands.UpdateParkingService;

public class UpdateParkingServiceCommandValidator : AbstractValidator<UpdateParkingServiceCommand>
{
    public UpdateParkingServiceCommandValidator()
    {
        RuleFor(c => c.Id).NotNull()
            .WithMessage("Park hizmeti seçilmelidir.");
        RuleFor(c => c.VehicleId).NotNull()
            .WithMessage("Araç belirtilmelidir.");
        RuleFor(c => c.ParkPriceId).NotNull()
            .WithMessage("Park ücreti belirtilmelidir.");
        RuleFor(c => c.ParkingLotId).NotNull()
            .WithMessage("Park yeri belirtilmelidir.");
        RuleFor(c => c.Total).NotNull()
            .WithMessage("Toplam ücret belirtilmelidir.");
        RuleFor(c => c.TotalHour).NotNull()
            .WithMessage("Park süresi belirtilmelidir.");
        RuleFor(c => c.CompanyId).NotNull()
            .WithMessage("Şirket belirtilmelidir.");
    }
}