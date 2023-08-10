using AutoMapper;
using AutoMapper.QueryableExtensions;
using CPMS.Application.Common.Interfaces;
using CPMS.Application.ParkingServices.Queries.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CPMS.Application.ParkingServices.Queries.GetParkingServices;

public class GetParkingServicesQueryHandler : IRequestHandler<GetParkingServicesQuery,List<ParkingServiceDto>>
{
    private readonly IApplicationContext _context;
    private readonly IMapper _mapper;

    public GetParkingServicesQueryHandler(IApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ParkingServiceDto>> Handle(GetParkingServicesQuery request, CancellationToken cancellationToken)
    {
        return await _context
            .ParkingServices
            .Where(c => (request.CompanyId == null || c.CompanyId == request.CompanyId))
            .Include(c => c.Vehicle)
            .Include(c => c.ParkingLot)
            .Include(c => c.ParkPrice)
            .ProjectTo<ParkingServiceDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}