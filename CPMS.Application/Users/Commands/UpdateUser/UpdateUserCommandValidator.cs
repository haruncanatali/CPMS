using FluentValidation;

namespace CPMS.Application.Users.Commands.UpdateUser;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(c => c.FirstName).NotEmpty().WithName("Ad boş olmamalıdır.");
        RuleFor(c => c.LastName).NotEmpty().WithName("Soyad boş olmamalıdır.");
        RuleFor(c => c.Birthdate).NotEmpty().WithName("Doğum tarihi boş olmamalıdır.");
        RuleFor(c => c.IdentificationNumber).NotEmpty().WithName("T.C. Kimlik No boş olmamalıdır.");
        RuleFor(c => c.Gender).NotEmpty().WithName("Cinsiyet boş olmamalıdır.");
    }
}