using CPMS.Application.ServicePrices.Queries.Dtos;
using MediatR;

namespace CPMS.Application.ServicePrices.Queries.GetServicePrice;

public class GetServicePriceQuery : IRequest<ServicePriceDto>
{
    public long Id { get; set; }
}