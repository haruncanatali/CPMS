using CPMS.Application.Common.Interfaces;
using CPMS.Domain.Entities;
using CPMS.Domain.Enums;
using MediatR;

namespace CPMS.Application.ServicePrices.Commands.CreateServicePrice;

public class CreateServicePriceCommand : IRequest<Unit>
{
    public VehicleType VehicleType { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public long CompanyId { get; set; }
    
    public class Handler : IRequestHandler<CreateServicePriceCommand,Unit>
    {
        private readonly IApplicationContext _context;
        
        public async Task<Unit> Handle(CreateServicePriceCommand request, CancellationToken cancellationToken)
        {
            await _context.ServicePrices.AddAsync(new ServicePrice
            {
                VehicleType = request.VehicleType,
                Name = request.Name,
                Price = request.Price,
                CompanyId = request.CompanyId
            }, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}