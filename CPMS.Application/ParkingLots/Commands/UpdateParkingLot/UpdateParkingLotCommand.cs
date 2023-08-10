using CPMS.Application.Common.Interfaces;
using CPMS.Domain.Entities;
using CPMS.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CPMS.Application.ParkingLots.Commands.UpdateParkingLot;

public class UpdateParkingLotCommand : IRequest<Unit>
{
    public long Id { get; set; }
    public string Name { get; set; }
    public VehicleType VehicleType { get; set; }
    public long CompanyId { get; set; }
    
    public class Handler : IRequestHandler<UpdateParkingLotCommand,Unit>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateParkingLotCommand request, CancellationToken cancellationToken)
        {
            ParkingLot? parkingLot = await _context.ParkingLots
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (parkingLot != null)
            {
                parkingLot.Name = request.Name;
                parkingLot.VehicleType = request.VehicleType;
                parkingLot.CompanyId = request.CompanyId;

                _context.ParkingLots.Update(parkingLot);
                await _context.SaveChangesAsync(cancellationToken);
            }
            
            return Unit.Value;
        }
    }
}