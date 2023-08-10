using AutoMapper;
using CPMS.Application.Common.Mappings;
using CPMS.Domain.Entities;

namespace CPMS.Application.ParkingServices.Queries.Dtos;

public class ParkingServiceDto : IMapFrom<ParkingService>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<ParkingService, ParkingServiceDto>();
    }
}