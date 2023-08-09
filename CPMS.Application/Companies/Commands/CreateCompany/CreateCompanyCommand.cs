using CPMS.Application.Common.Interfaces;
using CPMS.Domain.Entities;
using MediatR;

namespace CPMS.Application.Companies.Commands.CreateCompany;

public class CreateCompanyCommand : IRequest<Unit>
{
    public string Name { get; set; }
    public string Address { get; set; }
    public double Lat { get; set; }
    public double Lon { get; set; }

    public class Handler : IRequestHandler<CreateCompanyCommand, Unit>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            await _context.Companies.AddAsync(new Company
            {
                Name = request.Name,
                Address = request.Address,
                Lat = request.Lat,
                Lon = request.Lon
            },cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}