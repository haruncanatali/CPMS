using CPMS.Application.Common.Interfaces;
using CPMS.Domain.Entities;
using CPMS.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CPMS.Application.Vehicles.Commands.DeleteVehicle;

public class DeleteVehicleCommand : IRequest<Unit>
{
    public long Id { get; set; }
    
    public class Handler : IRequestHandler<DeleteVehicleCommand,Unit>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteVehicleCommand request, CancellationToken cancellationToken)
        {
            Vehicle? vehicle = await _context.Vehicles
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (vehicle != null)
            {
                vehicle.EntityStatus = EntityStatus.Passive;
                await _context.SaveChangesAsync(cancellationToken);
            }
            
            return Unit.Value;
        }
    }
}