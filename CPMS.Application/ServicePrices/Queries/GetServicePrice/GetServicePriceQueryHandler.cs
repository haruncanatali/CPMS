using AutoMapper;
using AutoMapper.QueryableExtensions;
using CPMS.Application.Common.Interfaces;
using CPMS.Application.ServicePrices.Queries.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CPMS.Application.ServicePrices.Queries.GetServicePrice;

public class GetServicePriceQueryHandler : IRequestHandler<GetServicePriceQuery,ServicePriceDto>
{
    private readonly IApplicationContext _context;
    private readonly IMapper _mapper;

    public GetServicePriceQueryHandler(IApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServicePriceDto> Handle(GetServicePriceQuery request, CancellationToken cancellationToken)
    {
        return await _context
            .ServicePrices
            .Where(c => c.Id == request.Id)
            .ProjectTo<ServicePriceDto>(_mapper.ConfigurationProvider)
            .FirstAsync(cancellationToken);
    }
}