using AutoMapper;
using AutoMapper.QueryableExtensions;
using CPMS.Application.Common.Interfaces;
using CPMS.Application.ParkPrices.Queries.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CPMS.Application.ParkPrices.Queries.GetParkPrice;

public class GetParkPriceQueryHandler : IRequestHandler<GetParkPriceQuery,ParkPriceDto>
{
    private readonly IApplicationContext _context;
    private readonly IMapper _mapper;

    public GetParkPriceQueryHandler(IApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ParkPriceDto> Handle(GetParkPriceQuery request, CancellationToken cancellationToken)
    {
        return await _context
            .ParkPrices
            .Where(c => c.Id == request.Id)
            .ProjectTo<ParkPriceDto>(_mapper.ConfigurationProvider)
            .FirstAsync(cancellationToken);
    }
}