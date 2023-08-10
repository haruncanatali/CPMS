using CPMS.Application.ParkingServices.Queries.Dtos;
using MediatR;

namespace CPMS.Application.ParkingServices.Queries.GetParkingServices;

public class GetParkingServicesQuery : IRequest<List<ParkingServiceDto>>
{
    public long? CompanyId { get; set; }
}