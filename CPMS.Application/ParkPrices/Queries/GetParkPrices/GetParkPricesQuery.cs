using CPMS.Application.ParkPrices.Queries.Dtos;
using MediatR;

namespace CPMS.Application.ParkPrices.Queries.GetParkPrices;

public class GetParkPricesQuery : IRequest<List<ParkPriceDto>>
{
    public long? CompanyId { get; set; }
}