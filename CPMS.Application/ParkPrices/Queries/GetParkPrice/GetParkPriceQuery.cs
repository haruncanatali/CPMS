using CPMS.Application.ParkPrices.Queries.Dtos;
using MediatR;

namespace CPMS.Application.ParkPrices.Queries.GetParkPrice;

public class GetParkPriceQuery : IRequest<ParkPriceDto>
{
    public long Id { get; set; }
}