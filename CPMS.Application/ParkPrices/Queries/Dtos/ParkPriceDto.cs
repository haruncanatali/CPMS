using AutoMapper;
using CPMS.Application.Common.Mappings;
using CPMS.Domain.Entities;
using CPMS.Domain.Enums;

namespace CPMS.Application.ParkPrices.Queries.Dtos;

public class ParkPriceDto : IMapFrom<ParkPrice>
{
    public long Id { get; set; }
    public VehicleType VehicleType { get; set; }
    public decimal Price { get; set; }
    public long CompanyId { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<ParkPrice, ParkPriceDto>();
    }
}