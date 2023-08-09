using CPMS.Application.Common.Interfaces;
using CPMS.Domain.Entities;
using CPMS.Domain.Enums;
using MediatR;

namespace CPMS.Application.Settings.Commands.CreateSetting;

public class CreateSettingCommand : IRequest<Unit>
{
    public SettingType SettingType { get; set; }
    public string Value { get; set; }
    public long CompanyId { get; set; }
    
    public class Handler : IRequestHandler<CreateSettingCommand,Unit>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateSettingCommand request, CancellationToken cancellationToken)
        {
            await _context.Settings.AddAsync(new Setting
            {
                SettingType = request.SettingType,
                Value = request.Value,
                CompanyId = request.CompanyId
            }, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}