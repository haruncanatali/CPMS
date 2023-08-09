using CPMS.Application.Common.Interfaces;
using CPMS.Domain.Entities;
using CPMS.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CPMS.Application.ServicePrices.Commands.UpdateServicePrice;

public class UpdateServicePriceCommand : IRequest<Unit>
{
    public long Id { get; set; }
    public VehicleType VehicleType { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public long CompanyId { get; set; }
    
    public class Handler : IRequestHandler<UpdateServicePriceCommand,Unit>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateServicePriceCommand request, CancellationToken cancellationToken)
        {
            ServicePrice? servicePrice = await _context.ServicePrices
                .FirstOrDefaultAsync(c => c.Id == request.Id,cancellationToken);

            if (servicePrice != null)
            {
                servicePrice.VehicleType = request.VehicleType;
                servicePrice.Name = request.Name;
                servicePrice.Price = request.Price;
                servicePrice.CompanyId = request.CompanyId;

                _context.ServicePrices.Update(servicePrice);
                await _context.SaveChangesAsync(cancellationToken);
            }
            
            return Unit.Value;
        }
    }
}