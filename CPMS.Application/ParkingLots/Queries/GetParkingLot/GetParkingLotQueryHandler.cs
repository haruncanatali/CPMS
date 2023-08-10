using AutoMapper;
using AutoMapper.QueryableExtensions;
using CPMS.Application.Common.Interfaces;
using CPMS.Application.ParkingLots.Queries.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CPMS.Application.ParkingLots.Queries.GetParkingLot;

public class GetParkingLotQueryHandler : IRequestHandler<GetParkingLotQuery,ParkingLotDto>
{
    private readonly IApplicationContext _context;
    private readonly IMapper _mapper;

    public GetParkingLotQueryHandler(IApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ParkingLotDto> Handle(GetParkingLotQuery request, CancellationToken cancellationToken)
    {
        return await _context
            .ParkingLots
            .Where(c => c.Id == request.Id)
            .Include(c => c.ParkingServices)
            .ProjectTo<ParkingLotDto>(_mapper.ConfigurationProvider)
            .FirstAsync(cancellationToken);
    }
}