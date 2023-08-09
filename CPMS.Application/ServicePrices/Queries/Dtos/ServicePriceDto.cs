using AutoMapper;
using CPMS.Application.Common.Mappings;
using CPMS.Domain.Entities;
using CPMS.Domain.Enums;

namespace CPMS.Application.ServicePrices.Queries.Dtos;

public class ServicePriceDto : IMapFrom<ServicePrice>
{
    public VehicleType VehicleType { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public long CompanyId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ServicePrice, ServicePriceDto>();
    }
}