using AutoMapper;
using AutoMapper.QueryableExtensions;
using CPMS.Application.Common.Interfaces;
using CPMS.Application.Customers.Queries.Dtos;
using CPMS.Application.Vehicles.Queries.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CPMS.Application.Customers.Queries.GetCustomer;

public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery,CustomerDto>
{
    private readonly IApplicationContext _context;
    private readonly IMapper _mapper;

    public GetCustomerQueryHandler(IApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CustomerDto> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        return await _context.Customers
            .Where(c => c.Id == request.Id)
            .Include(c => c.Vehicles)
            .ProjectTo<CustomerDto>(_mapper.ConfigurationProvider)
            .FirstAsync(cancellationToken);
    }
}