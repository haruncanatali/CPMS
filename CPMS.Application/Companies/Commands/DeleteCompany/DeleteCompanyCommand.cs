using CPMS.Application.Common.Interfaces;
using CPMS.Domain.Entities;
using CPMS.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CPMS.Application.Companies.Commands.DeleteCompany;

public class DeleteCompanyCommand : IRequest<Unit>
{
    public long Id { get; set; }

    public class Handler : IRequestHandler<DeleteCompanyCommand, Unit>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            Company? company = await _context.Companies
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (company != null)
            {
                company.EntityStatus = EntityStatus.Passive;
                await _context.SaveChangesAsync(cancellationToken);
            }
            
            return Unit.Value;
        }
    }
}