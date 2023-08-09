using CPMS.Application.Common.Interfaces;
using CPMS.Domain.Entities;
using CPMS.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CPMS.Application.Settings.Commands.UpdateSetting;

public class UpdateSettingCommand : IRequest<Unit>
{
    public long Id { get; set; }
    public SettingType SettingType { get; set; }
    public string Value { get; set; }
    public long CompanyId { get; set; }
    
    public class Handler : IRequestHandler<UpdateSettingCommand,Unit>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateSettingCommand request, CancellationToken cancellationToken)
        {
            Setting? setting = await _context.Settings
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (setting != null)
            {
                setting.SettingType = request.SettingType;
                setting.Value = request.Value;
                setting.CompanyId = request.CompanyId;

                _context.Settings.Update(setting);
                await _context.SaveChangesAsync(cancellationToken);
            }
            
            return Unit.Value;
        }
    }
}