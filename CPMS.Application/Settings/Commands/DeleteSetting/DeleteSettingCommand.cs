using CPMS.Application.Common.Interfaces;
using CPMS.Domain.Entities;
using CPMS.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CPMS.Application.Settings.Commands.DeleteSetting;

public class DeleteSettingCommand : IRequest<Unit>
{
    public long Id { get; set; }
    
    public class Handler : IRequestHandler<DeleteSettingCommand,Unit>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteSettingCommand request, CancellationToken cancellationToken)
        {
            Setting? setting = await _context.Settings
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (setting != null)
            {
                setting.EntityStatus = EntityStatus.Passive;

                _context.Settings.Update(setting);
                await _context.SaveChangesAsync(cancellationToken);
            }
            
            return Unit.Value;
        }
    }
}