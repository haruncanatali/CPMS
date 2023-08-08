using AutoMapper;
using AutoMapper.QueryableExtensions;
using CPMS.Application.Common.Interfaces;
using CPMS.Application.Vehicles.Queries.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CPMS.Application.Vehicles.Queries.GetVehicle;

public class GetVehicleQueryHandler : IRequestHandler<GetVehicleQuery,VehicleDto>
{
    private readonly IApplicationContext _context;
    private readonly IMapper _mapper;

    public GetVehicleQueryHandler(IApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<VehicleDto> Handle(GetVehicleQuery request, CancellationToken cancellationToken)
    {
        return await _context.Vehicles
            .Include(c=>c.Customer)
            .Include(c=>c.Model)
            .Where(c => c.Id == request.Id)
            .ProjectTo<VehicleDto>(_mapper.ConfigurationProvider)
            .FirstAsync(cancellationToken);
    }
}