using CPMS.Application.Common.Interfaces;
using CPMS.Domain.Entities;
using CPMS.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CPMS.Application.ParkPrices.Commands.DeleteParkPrice;

public class DeleteParkPriceCommand : IRequest<Unit>
{
    public long Id { get; set; }
    
    public class Handler : IRequestHandler<DeleteParkPriceCommand,Unit>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteParkPriceCommand request, CancellationToken cancellationToken)
        {
            ParkPrice? parkPrice = await _context.ParkPrices
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (parkPrice != null)
            {
                parkPrice.EntityStatus = EntityStatus.Passive;

                _context.ParkPrices.Update(parkPrice);
                await _context.SaveChangesAsync(cancellationToken);
            }
            
            return Unit.Value;
        }
    }
}