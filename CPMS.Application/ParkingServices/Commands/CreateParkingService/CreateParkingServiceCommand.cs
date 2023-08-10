using CPMS.Application.Common.Interfaces;
using CPMS.Domain.Entities;
using MediatR;

namespace CPMS.Application.ParkingServices.Commands.CreateParkingService;

public class CreateParkingServiceCommand : IRequest<Unit>
{
    public long VehicleId { get; set; }
    public long ParkPriceId { get; set; }
    public long ParkingLotId { get; set; }
    public long CompanyId { get; set; }
    public decimal Total { get; set; }
    public int TotalHour { get; set; }
    
    public class Handler : IRequestHandler<CreateParkingServiceCommand,Unit>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateParkingServiceCommand request, CancellationToken cancellationToken)
        {
            await _context.ParkingServices.AddAsync(new ParkingService
            {
                CompanyId = request.CompanyId,
                VehicleId = request.VehicleId,
                ParkPriceId = request.ParkPriceId,
                ParkingLotId = request.ParkingLotId,
                Total = request.Total,
                TotalHour = request.TotalHour
            },cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}