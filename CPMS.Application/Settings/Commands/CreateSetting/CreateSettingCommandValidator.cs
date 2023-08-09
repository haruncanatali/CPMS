using FluentValidation;

namespace CPMS.Application.Settings.Commands.CreateSetting;

public class CreateSettingCommandValidator : AbstractValidator<CreateSettingCommand>
{
    public CreateSettingCommandValidator()
    {
        RuleFor(c => c.SettingType).NotNull()
            .WithMessage("Ayar tipi boş olmamalıdır.");
        RuleFor(c => c.Value).NotEmpty()
            .WithMessage("Değer boş olmamalıdır.");
        RuleFor(c => c.CompanyId).NotNull()
            .WithMessage("Şirket belirtilmelidir.");
    }
}