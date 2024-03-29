using FluentValidation;

namespace CPMS.Application.Users.Commands.CreateUser;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(c => c.FirstName).NotNull().WithMessage("Ad girilmelidir.");
        RuleFor(c => c.LastName).NotNull().WithMessage("Soyad girilmelidir.");
        RuleFor(c => c.Email).NotNull().WithMessage("Mail girilmelidir.");
        RuleFor(c => c.Password).NotNull().WithMessage("Şifre girilmelidir.");
        RuleFor(c => c.Birthdate).NotNull().WithMessage("Doğum tarihi girilmelidir.");
        RuleFor(c => c.ProfilePhoto).NotNull().WithMessage("Fotoğraf girilmelidir.");
        RuleFor(c => c.IdentificationNumber).NotEmpty().WithName("T.C. Kimlik No boş olmamalıdır.");
        RuleFor(c => c.Gender).NotEmpty().WithName("Cinsiyet boş olmamalıdır.");
    }
}