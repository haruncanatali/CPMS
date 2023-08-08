using AutoMapper;
using CPMS.Application.Common.Mappings;
using CPMS.Application.Vehicles.Queries.Dtos;
using CPMS.Domain.Entities;
using CPMS.Domain.Enums;

namespace CPMS.Application.Customers.Queries.Dtos;

public class CustomerDto : IMapFrom<Customer>
{
    public long Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string IdentificationNumber { get; set; }
    public string DriverLicenseNumber { get; set; }
    public string ProfilePhoto { get; set; }
    public Gender Gender { get; set; }
    public List<VehicleDto> Vehicles { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Customer, CustomerDto>()
            .ForMember(dest => dest.Vehicles, opt => opt
                .MapFrom(c => c.Vehicles));
    }
}