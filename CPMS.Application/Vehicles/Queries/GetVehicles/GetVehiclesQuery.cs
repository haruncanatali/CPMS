using CPMS.Application.Vehicles.Queries.Dtos;
using MediatR;

namespace CPMS.Application.Vehicles.Queries.GetVehicles;

public class GetVehiclesQuery : IRequest<List<VehicleDto>>
{
    public string? Plate { get; set; }
}