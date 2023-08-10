using CPMS.Application.Common.Interfaces;
using CPMS.Domain.Entities;
using CPMS.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CPMS.Application.ParkingLots.Commands.DeleteParkingLot;

public class DeleteParkingLotCommand : IRequest<Unit>
{
    public long Id { get; set; }
    
    public class Handler : IRequestHandler<DeleteParkingLotCommand,Unit>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteParkingLotCommand request, CancellationToken cancellationToken)
        {
            ParkingLot? parkingLot = await _context.ParkingLots
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (parkingLot != null)
            {
                parkingLot.EntityStatus = EntityStatus.Passive;
                _context.ParkingLots.Update(parkingLot);

                await _context.SaveChangesAsync(cancellationToken);
            }
            
            return Unit.Value;
        }
    }
}