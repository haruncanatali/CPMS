using AutoMapper;
using CPMS.Application.Common.Mappings;
using CPMS.Application.Customers.Queries.Dtos;
using CPMS.Application.Models.Queries.Dtos;
using CPMS.Domain.Entities;

namespace CPMS.Application.Vehicles.Queries.Dtos;

public class VehicleDto : IMapFrom<Vehicle>
{
    public long Id { get; set; }
    public string Plate { get; set; }
    public string Color { get; set; }
    public bool LPG { get; set; }
    public string VehiclePhoto { get; set; }
    public long CustomerId { get; set; }
    public long ModelId { get; set; }
    public CustomerDto Customer { get; set; }
    public ModelDto Model { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Vehicle, VehicleDto>()
            .ForMember(dest => dest.Customer, opt => opt
                .MapFrom(c => c.Customer))
            .ForMember(dest => dest.Model, opt => opt
                .MapFrom(c => c.Model));
    }
}