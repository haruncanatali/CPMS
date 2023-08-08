using CPMS.Application.Common.Interfaces;
using CPMS.Domain.Entities;
using CPMS.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CPMS.Application.Models.Commands.DeleteModel;

public class DeleteModelCommand : IRequest<Unit>
{
    public long Id { get; set; }

    public class Handler : IRequestHandler<DeleteModelCommand, Unit>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteModelCommand request, CancellationToken cancellationToken)
        {
            Model? model = await _context.Models
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (model != null)
            {
                model.EntityStatus = EntityStatus.Passive;
                _context.Models.Update(model);
                await _context.SaveChangesAsync(cancellationToken);
            }
            
            return Unit.Value;
        }
    }
}