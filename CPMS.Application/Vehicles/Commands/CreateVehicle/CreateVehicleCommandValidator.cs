using FluentValidation;

namespace CPMS.Application.Vehicles.Commands.CreateVehicle;

public class CreateVehicleCommandValidator : AbstractValidator<CreateVehicleCommand>
{
    public CreateVehicleCommandValidator()
    {
        RuleFor(c => c.Plate).NotEmpty()
            .WithMessage("Plaka boş olmamalıdır.");
        RuleFor(c => c.Color).NotEmpty()
            .WithMessage("Renk boş olmamalıdır.");
        RuleFor(c => c.LPG).NotNull()
            .WithMessage("LPG bilgisi boş olmamalıdır.");
        RuleFor(c => c.CustomerId).NotNull()
            .WithMessage("Müşteri boş olmamalıdır.");
        RuleFor(c => c.ModelId).NotNull()
            .WithMessage("Model boş olmamalıdır.");
        RuleFor(c => c.VehiclePhoto).NotNull()
            .WithMessage("Araç fotoğrafı boş olmamalıdır.");
    }
}