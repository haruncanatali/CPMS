using AutoMapper;
using CPMS.Application.Common.Mappings;
using CPMS.Application.Users.Queries.Dtos;
using CPMS.Domain.Entities;

namespace CPMS.Application.Companies.Queries.Dtos;

public class CompanyDto : IMapFrom<Company>
{
    public long Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<UserDto> Users { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Company, CompanyDto>()
            .ForMember(dest => dest.Users, opt => opt
                .MapFrom(c => c.Users));
    }
}