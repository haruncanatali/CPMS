using FluentValidation;

namespace CPMS.Application.Settings.Commands.UpdateSetting;

public class UpdateSettingCommandValidator : AbstractValidator<UpdateSettingCommand>
{
    public UpdateSettingCommandValidator()
    {
        RuleFor(c => c.Id).NotNull()
            .WithMessage("Ayar belirtilmelidir.");
        RuleFor(c => c.SettingType).NotNull()
            .WithMessage("Ayar tipi boş olmamalıdır.");
        RuleFor(c => c.Value).NotEmpty()
            .WithMessage("Değer boş olmamalıdır.");
        RuleFor(c => c.CompanyId).NotNull()
            .WithMessage("Şirket belirtilmelidir.");
    }
}