using CPMS.Application.Common.Interfaces;
using CPMS.Domain.Entities;
using CPMS.Domain.Enums;
using MediatR;

namespace CPMS.Application.ParkingLots.Commands.CreateParkingLot;

public class CreateParkingLotCommand : IRequest<Unit>
{
    public string Name { get; set; }
    public VehicleType VehicleType { get; set; }
    public long CompanyId { get; set; }
    
    public class Handler : IRequestHandler<CreateParkingLotCommand,Unit>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateParkingLotCommand request, CancellationToken cancellationToken)
        {
            await _context.ParkingLots.AddAsync(new ParkingLot
            {
                Name = request.Name,
                VehicleType = request.VehicleType,
                CompanyId = request.CompanyId
            });

            await _context.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}