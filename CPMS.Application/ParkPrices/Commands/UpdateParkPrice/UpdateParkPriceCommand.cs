using CPMS.Application.Common.Interfaces;
using CPMS.Domain.Entities;
using CPMS.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CPMS.Application.ParkPrices.Commands.UpdateParkPrice;

public class UpdateParkPriceCommand : IRequest<Unit>
{
    
    public long Id { get; set; }
    public VehicleType VehicleType { get; set; }
    public decimal Price { get; set; }
    public long CompanyId { get; set; }
    
    public class Handler : IRequestHandler<UpdateParkPriceCommand,Unit>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateParkPriceCommand request, CancellationToken cancellationToken)
        {
            ParkPrice? parkPrice = await _context.ParkPrices
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (parkPrice != null)
            {
                parkPrice.VehicleType = request.VehicleType;
                parkPrice.Price = request.Price;
                parkPrice.CompanyId = request.CompanyId;

                _context.ParkPrices.Update(parkPrice);
                await _context.SaveChangesAsync(cancellationToken);
            }
            
            return Unit.Value;
        }
    }
}