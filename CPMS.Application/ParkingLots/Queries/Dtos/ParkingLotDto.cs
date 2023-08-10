using AutoMapper;
using CPMS.Application.Common.Mappings;
using CPMS.Application.ParkingServices.Queries.Dtos;
using CPMS.Domain.Entities;
using CPMS.Domain.Enums;

namespace CPMS.Application.ParkingLots.Queries.Dtos;

public class ParkingLotDto : IMapFrom<ParkingLot>
{
    public long Id { get; set; }
    public string Name { get; set; }
    public VehicleType VehicleType { get; set; }
    public long CompanyId { get; set; }
    public List<ParkingServiceDto> ParkingServices { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ParkingLot, ParkingLotDto>()
            .ForMember(dest => dest.ParkingServices,opt => opt
                .MapFrom(c=>c.ParkingServices));
    }
}