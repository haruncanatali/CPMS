using CPMS.Application.Common.Interfaces;
using CPMS.Domain.Entities;
using MediatR;

namespace CPMS.Application.Models.Commands.CreateModel;

public class CreateModelCommand : IRequest<Unit>
{
    public string Name { get; set; }
    public long BrandId { get; set; }

    public class Handler : IRequestHandler<CreateModelCommand, Unit>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateModelCommand request, CancellationToken cancellationToken)
        {
            await _context.Models.AddAsync(new Model
            {
                Name = request.Name,
                BrandId = request.BrandId
            });

            await _context.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}