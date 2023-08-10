using AutoMapper;
using AutoMapper.QueryableExtensions;
using CPMS.Application.Common.Interfaces;
using CPMS.Application.ParkPrices.Queries.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CPMS.Application.ParkPrices.Queries.GetParkPrices;

public class GetParkPricesQueryHandler : IRequestHandler<GetParkPricesQuery,List<ParkPriceDto>>
{
    private readonly IApplicationContext _context;
    private readonly IMapper _mapper;

    public GetParkPricesQueryHandler(IApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ParkPriceDto>> Handle(GetParkPricesQuery request, CancellationToken cancellationToken)
    {
        return await _context
            .ParkPrices
            .Where(c => (request.CompanyId == null || c.CompanyId == request.CompanyId))
            .ProjectTo<ParkPriceDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}