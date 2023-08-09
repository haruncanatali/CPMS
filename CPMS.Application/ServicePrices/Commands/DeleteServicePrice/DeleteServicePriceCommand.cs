using CPMS.Application.Common.Interfaces;
using CPMS.Domain.Entities;
using CPMS.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CPMS.Application.ServicePrices.Commands.DeleteServicePrice;

public class DeleteServicePriceCommand : IRequest<Unit>
{
    public long Id { get; set; }
    
    public class Handler : IRequestHandler<DeleteServicePriceCommand,Unit>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteServicePriceCommand request, CancellationToken cancellationToken)
        {
            ServicePrice? servicePrice = await _context.ServicePrices
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (servicePrice != null)
            {
                servicePrice.EntityStatus = EntityStatus.Passive;

                _context.ServicePrices.Update(servicePrice);

                await _context.SaveChangesAsync(cancellationToken);
            }
            
            return Unit.Value;
        }
    }
}