using CPMS.Application.ServicePrices.Queries.Dtos;
using MediatR;

namespace CPMS.Application.ServicePrices.Queries.GetServicePrices;

public class GetServicePricesQuery : IRequest<List<ServicePriceDto>>
{
    public long? CompanyId { get; set; }
}