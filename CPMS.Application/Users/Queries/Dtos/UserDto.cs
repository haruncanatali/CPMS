using AutoMapper;
using CPMS.Application.Common.Mappings;
using CPMS.Domain.IdentityEntities;

namespace CPMS.Application.Users.Queries.Dtos;

public class UserDto : IMapFrom<User>
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ProfilePhoto { get; set; }
    public DateTime Birthdate { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public DateTime CreatedAt { get; set; }
    public string CompanyName { get; set; }
    public long CompanyId { get; set; }
    
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<User, UserDto>()
            .ForMember(dest => dest.CompanyName, opt => opt
                .MapFrom(c=>c.Company.Name))
            .ForMember(dest => dest.CompanyId, opt => opt
                .MapFrom(c=>c.Company.Id));
    }
}