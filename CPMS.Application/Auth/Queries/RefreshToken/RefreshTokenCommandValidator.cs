using FluentValidation;

namespace CPMS.Application.Auth.Queries.RefreshToken;

public class RefreshTokenCommandValidator : AbstractValidator<RefreshTokenCommand>
{
    public RefreshTokenCommandValidator()
    {
        RuleFor(c => c.RefreshToken).NotEmpty().WithMessage("Parametre hatası!");
    }
}