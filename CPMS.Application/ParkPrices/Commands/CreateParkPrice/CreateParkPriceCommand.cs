using CPMS.Application.Common.Interfaces;
using CPMS.Domain.Entities;
using CPMS.Domain.Enums;
using MediatR;

namespace CPMS.Application.ParkPrices.Commands.CreateParkPrice;

public class CreateParkPriceCommand : IRequest<Unit>
{
    public VehicleType VehicleType { get; set; }
    public decimal Price { get; set; }
    public long CompanyId { get; set; }
    
    public class Handler : IRequestHandler<CreateParkPriceCommand,Unit>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateParkPriceCommand request, CancellationToken cancellationToken)
        {
            await _context.ParkPrices.AddAsync(new ParkPrice
            {
                VehicleType = request.VehicleType,
                Price = request.Price,
                CompanyId = request.CompanyId
            });

            await _context.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}