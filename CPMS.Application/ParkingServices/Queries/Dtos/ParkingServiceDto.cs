using AutoMapper;
using CPMS.Application.Common.Mappings;
using CPMS.Application.Vehicles.Queries.Dtos;
using CPMS.Domain.Entities;

namespace CPMS.Application.ParkingServices.Queries.Dtos;

public class ParkingServiceDto : IMapFrom<ParkingService>
{
    public long VehicleId { get; set; }
    public long ParkPriceId { get; set; }
    public long ParkingLotId { get; set; }
    public long CompanyId { get; set; }
    public decimal Total { get; set; }
    public int TotalHour { get; set; }

    public VehicleDto Vehicle { get; set; }
    public ParkPrice ParkPrice { get; set; }
    public ParkingLot ParkingLot { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<ParkingService, ParkingServiceDto>()
            .ForMember(dest => dest.Vehicle,opt => opt
                .MapFrom(c=>c.Vehicle))
            .ForMember(dest => dest.ParkPrice,opt => opt
                .MapFrom(c=>c.ParkPrice))
            .ForMember(dest => dest.ParkingLot,opt => opt
                .MapFrom(c=>c.ParkingLot));
    }
}