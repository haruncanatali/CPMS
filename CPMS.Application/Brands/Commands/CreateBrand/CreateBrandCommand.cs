using CPMS.Application.Common.Interfaces;
using CPMS.Domain.Entities;
using MediatR;

namespace CPMS.Application.Brands.Commands.CreateBrand;

public class CreateBrandCommand : IRequest<Unit>
{
    public string Name { get; set; }

    public class Handler : IRequestHandler<CreateBrandCommand, Unit>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            await _context.Brands.AddAsync(new Brand
            {
                Name = request.Name
            });

            await _context.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}