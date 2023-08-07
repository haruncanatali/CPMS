using CPMS.Application.Common.Interfaces;
using CPMS.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CPMS.Application.Companies.Commands.UpdateCompany;

public class UpdateCompanyCommand : IRequest<Unit>
{
    public long Id { get; set; }
    public string Name { get; set; }

    public class Handler : IRequestHandler<UpdateCompanyCommand, Unit>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            Company? company = await _context.Companies
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (company != null)
            {
                company.Name = request.Name;
                await _context.SaveChangesAsync(cancellationToken);
            }
            
            return Unit.Value;
        }
    }
}