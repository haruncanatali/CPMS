using CPMS.Application.ParkingLots.Queries.Dtos;
using MediatR;

namespace CPMS.Application.ParkingLots.Queries.GetParkingLots;

public class GetParkingLotsQuery : IRequest<List<ParkingLotDto>>
{
    public long? CompanyId { get; set; }
}