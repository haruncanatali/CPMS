using AutoMapper;
using CPMS.Application.Common.Mappings;
using CPMS.Application.Models.Queries.Dtos;
using CPMS.Domain.Entities;

namespace CPMS.Application.Brands.Queries.Dtos;

public class BrandDto : IMapFrom<Brand>
{
    public long Id { get; set; }
    public string Name { get; set; }
    public List<ModelDto> Models { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Brand, BrandDto>()
            .ForMember(dest => dest.Models, opt => opt
                .MapFrom(c => c.Models));
    }
}