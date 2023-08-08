using CPMS.Application.Vehicles.Queries.Dtos;
using MediatR;

namespace CPMS.Application.Vehicles.Queries.GetVehicle;

public class GetVehicleQuery : IRequest<VehicleDto>
{
    public long Id { get; set; }
}