using FluentValidation;

namespace CPMS.Application.Settings.Commands.DeleteSetting;

public class DeleteSettingCommandValidator : AbstractValidator<DeleteSettingCommand>
{
    public DeleteSettingCommandValidator()
    {
        RuleFor(c => c.Id).NotNull()
            .WithMessage("Ayar belirtilmelidir.");
    }
}