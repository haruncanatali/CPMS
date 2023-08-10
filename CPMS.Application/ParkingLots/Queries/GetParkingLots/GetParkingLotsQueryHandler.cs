using AutoMapper;
using AutoMapper.QueryableExtensions;
using CPMS.Application.Common.Interfaces;
using CPMS.Application.ParkingLots.Queries.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CPMS.Application.ParkingLots.Queries.GetParkingLots;

public class GetParkingLotsQueryHandler : IRequestHandler<GetParkingLotsQuery,List<ParkingLotDto>>
{
    private readonly IApplicationContext _context;
    private readonly IMapper _mapper;

    public GetParkingLotsQueryHandler(IApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ParkingLotDto>> Handle(GetParkingLotsQuery request, CancellationToken cancellationToken)
    {
        return await _context
            .ParkingLots
            .Where(c => (request.CompanyId == null || c.CompanyId == request.CompanyId))
            .Include(c => c.ParkingServices)
            .ProjectTo<ParkingLotDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}