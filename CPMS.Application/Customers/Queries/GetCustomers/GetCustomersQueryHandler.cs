using AutoMapper;
using AutoMapper.QueryableExtensions;
using CPMS.Application.Common.Interfaces;
using CPMS.Application.Customers.Queries.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CPMS.Application.Customers.Queries.GetCustomers;

public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery,List<CustomerDto>>
{
    private readonly IApplicationContext _context;
    private readonly IMapper _mapper;

    public GetCustomersQueryHandler(IApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<CustomerDto>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
    {
        return await _context.Customers
            .Where(c =>
                (request.Email == null || c.Email.ToLower().Contains(request.Email.ToLower())) &&
                (request.Name == null || c.Name.ToLower().Contains(request.Name.ToLower())) &&
                (request.Surname == null || c.Surname.ToLower().Contains(request.Surname.ToLower())) &&
                (request.IdentificationNumber == null ||
                 c.IdentificationNumber.ToLower().Contains(request.IdentificationNumber.ToLower())))
            .Include(c => c.Vehicles)
            .ProjectTo<CustomerDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}