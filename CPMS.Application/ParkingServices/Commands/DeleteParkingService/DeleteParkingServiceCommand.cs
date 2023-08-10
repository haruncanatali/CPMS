using CPMS.Application.Common.Interfaces;
using CPMS.Domain.Entities;
using CPMS.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CPMS.Application.ParkingServices.Commands.DeleteParkingService;

public class DeleteParkingServiceCommand : IRequest<Unit>
{
    public long Id { get; set; }
    
    public class Handler : IRequestHandler<DeleteParkingServiceCommand,Unit>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteParkingServiceCommand request, CancellationToken cancellationToken)
        {
            ParkingService? parkingService = await _context.ParkingServices
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (parkingService != null)
            {
                parkingService.EntityStatus = EntityStatus.Passive;

                _context.ParkingServices.Update(parkingService);
                await _context.SaveChangesAsync(cancellationToken);
            }
            
            return Unit.Value;
        }
    }
}