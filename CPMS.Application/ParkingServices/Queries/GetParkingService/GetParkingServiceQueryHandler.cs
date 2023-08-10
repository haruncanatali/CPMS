using AutoMapper;
using AutoMapper.QueryableExtensions;
using CPMS.Application.Common.Interfaces;
using CPMS.Application.ParkingServices.Queries.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CPMS.Application.ParkingServices.Queries.GetParkingService;

public class GetParkingServiceQueryHandler : IRequestHandler<GetParkingServiceQuery,ParkingServiceDto>
{
    private readonly IApplicationContext _context;
    private readonly IMapper _mapper;

    public GetParkingServiceQueryHandler(IApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ParkingServiceDto> Handle(GetParkingServiceQuery request, CancellationToken cancellationToken)
    {
        return await _context
            .ParkingServices
            .Where(c => c.Id == request.Id)
            .Include(c => c.Vehicle)
            .Include(c => c.ParkingLot)
            .Include(c => c.ParkPrice)
            .ProjectTo<ParkingServiceDto>(_mapper.ConfigurationProvider)
            .FirstAsync(cancellationToken);
    }
}