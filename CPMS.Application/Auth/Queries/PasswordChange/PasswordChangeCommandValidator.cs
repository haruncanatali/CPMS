using FluentValidation;

namespace CPMS.Application.Auth.Queries.PasswordChange;

public class PasswordChangeCommandValidator : AbstractValidator<PasswordChangeCommand>
{
    public PasswordChangeCommandValidator()
    {
        RuleFor(c => c.Password).NotEmpty().WithMessage("Şifre girilmelidir.");
    }
}