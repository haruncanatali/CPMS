using AutoMapper;
using AutoMapper.QueryableExtensions;
using CPMS.Application.Common.Interfaces;
using CPMS.Application.ServicePrices.Queries.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CPMS.Application.ServicePrices.Queries.GetServicePrices;

public class GetServicePricesQueryHandler : IRequestHandler<GetServicePricesQuery,List<ServicePriceDto>>
{
    private readonly IApplicationContext _context;
    private readonly IMapper _mapper;

    public GetServicePricesQueryHandler(IApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ServicePriceDto>> Handle(GetServicePricesQuery request, CancellationToken cancellationToken)
    {
        return await _context
            .ServicePrices
            .Where(c => (request.CompanyId == null || c.CompanyId == request.CompanyId))
            .ProjectTo<ServicePriceDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}