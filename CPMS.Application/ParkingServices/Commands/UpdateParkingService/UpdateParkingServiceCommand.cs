using CPMS.Application.Common.Interfaces;
using CPMS.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CPMS.Application.ParkingServices.Commands.UpdateParkingService;

public class UpdateParkingServiceCommand : IRequest<Unit>
{
    public long Id { get; set; }
    public long VehicleId { get; set; }
    public long ParkPriceId { get; set; }
    public long ParkingLotId { get; set; }
    public long CompanyId { get; set; }
    public decimal Total { get; set; }
    public int TotalHour { get; set; }
    
    public class Handler : IRequestHandler<UpdateParkingServiceCommand,Unit>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateParkingServiceCommand request, CancellationToken cancellationToken)
        {
            ParkingService? parkingService = await _context.ParkingServices
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (parkingService != null)
            {
                parkingService.VehicleId = request.VehicleId;
                parkingService.ParkPriceId = request.ParkPriceId;
                parkingService.ParkingLotId = request.ParkingLotId;
                parkingService.Total = request.Total;
                parkingService.TotalHour = request.TotalHour;
                parkingService.CompanyId = request.CompanyId;

                _context.ParkingServices.Update(parkingService);
                await _context.SaveChangesAsync(cancellationToken);
            }
            
            return Unit.Value;
        }
    }
}