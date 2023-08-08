using AutoMapper;
using AutoMapper.QueryableExtensions;
using CPMS.Application.Common.Interfaces;
using CPMS.Application.Vehicles.Queries.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CPMS.Application.Vehicles.Queries.GetVehicles;

public class GetVehiclesQueryHandler : IRequestHandler<GetVehiclesQuery,List<VehicleDto>>
{
    private readonly IApplicationContext _context;
    private readonly IMapper _mapper;

    public GetVehiclesQueryHandler(IApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<VehicleDto>> Handle(GetVehiclesQuery request, CancellationToken cancellationToken)
    {
        return await _context.Vehicles
            .Where(c => (request.Plate == null || c.Plate.ToLower().Contains(request.Plate.ToLower())))
            .Include(c => c.Customer)
            .Include(c => c.Model)
            .ProjectTo<VehicleDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}