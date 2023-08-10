using CPMS.Application.ParkingLots.Queries.Dtos;
using MediatR;

namespace CPMS.Application.ParkingLots.Queries.GetParkingLot;

public class GetParkingLotQuery : IRequest<ParkingLotDto>
{
    public long Id { get; set; }
}