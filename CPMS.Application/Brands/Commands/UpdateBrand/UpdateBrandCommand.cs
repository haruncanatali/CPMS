using CPMS.Application.Common.Interfaces;
using CPMS.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CPMS.Application.Brands.Commands.UpdateBrand;

public class UpdateBrandCommand : IRequest<Unit>
{
    public long Id { get; set; }
    public string Name { get; set; }

    public class Handler : IRequestHandler<UpdateBrandCommand, Unit>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            Brand? brand = await _context.Brands
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (brand != null)
            {
                brand.Name = request.Name;
                await _context.SaveChangesAsync(cancellationToken);
            }
            
            return Unit.Value;
        }
    }
}