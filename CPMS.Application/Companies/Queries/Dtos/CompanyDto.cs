using AutoMapper;
using CPMS.Application.Common.Mappings;
using CPMS.Application.ParkingLots.Queries.Dtos;
using CPMS.Application.ParkingServices.Queries.Dtos;
using CPMS.Application.ParkPrices.Queries.Dtos;
using CPMS.Application.Settings.Queries.Dtos;
using CPMS.Application.Users.Queries.Dtos;
using CPMS.Domain.Entities;

namespace CPMS.Application.Companies.Queries.Dtos;

public class CompanyDto : IMapFrom<Company>
{
    public long Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<UserDto> Users { get; set; }
    public List<ParkPriceDto> ParkPrices { get; set; }
    public List<ParkingLotDto> ParkingLots { get; set; }
    public List<SettingDto> Settings { get; set; }
    public List<ParkingServiceDto> ParkingServices { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Company, CompanyDto>()
            .ForMember(dest => dest.Users, opt => opt
                .MapFrom(c => c.Users))
            .ForMember(dest => dest.ParkPrices, opt => opt
                .MapFrom(c => c.ParkPrices))
            .ForMember(dest => dest.ParkingLots, opt => opt
                .MapFrom(c => c.ParkingLots))
            .ForMember(dest => dest.Settings, opt => opt
                .MapFrom(c => c.Settings))
            .ForMember(dest => dest.ParkingServices, opt => opt
                .MapFrom(c => c.ParkingServices));
    }
}