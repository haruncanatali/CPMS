using CPMS.Application.Common.Interfaces;
using CPMS.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CPMS.Application.Models.Commands.UpdateModel;

public class UpdateModelCommand : IRequest<Unit>
{
    public long Id { get; set; }
    public long BrandId { get; set; }
    public string Name { get; set; }

    public class Handler : IRequestHandler<UpdateModelCommand, Unit>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateModelCommand request, CancellationToken cancellationToken)
        {
            Model? model = await _context.Models
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (model != null)
            {
                model.BrandId = request.BrandId;
                model.Name = request.Name;

                _context.Models.Update(model);
                await _context.SaveChangesAsync(cancellationToken);
            }
            
            return Unit.Value;
        }
    }
}