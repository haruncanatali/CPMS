using FluentValidation;

namespace CPMS.Application.Customers.Commands.UpdateCustomer;

public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCustomerCommandValidator()
    {
        RuleFor(c => c.Id).NotNull()
            .WithMessage("Müşteri belirtilmelidir.");
        RuleFor(c => c.Email).NotEmpty()
            .WithMessage("E-Posta boş olamaz.");
        RuleFor(c => c.Password).NotEmpty()
            .WithMessage("Şifre boş olamaz.");
        RuleFor(c => c.Name).NotEmpty()
            .WithMessage("Ad boş olamaz.");
        RuleFor(c => c.Surname).NotEmpty()
            .WithMessage("Soyad boş olamaz.");
        RuleFor(c => c.IdentificationNumber).NotEmpty()
            .WithMessage("T.C. Kimlik No boş olamaz.");
        RuleFor(c => c.DriverLicenseNumber).NotEmpty()
            .WithMessage("Ehliyet lisans numarası boş olamaz.");
        RuleFor(c => c.Gender).NotNull()
            .WithMessage("Cinsiyet boş olamaz.");
        RuleFor(c => c.Phone).NotEmpty()
            .WithMessage("Telefon numarası boş olamaz.");
    }
}