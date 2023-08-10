using CPMS.Application.ParkingServices.Queries.Dtos;
using MediatR;

namespace CPMS.Application.ParkingServices.Queries.GetParkingService;

public class GetParkingServiceQuery : IRequest<ParkingServiceDto>
{
    public long Id { get; set; }
}