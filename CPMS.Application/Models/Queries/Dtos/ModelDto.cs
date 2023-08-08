using AutoMapper;
using CPMS.Application.Common.Mappings;
using CPMS.Domain.Entities;

namespace CPMS.Application.Models.Queries.Dtos;

public class ModelDto : IMapFrom<Model>
{
    public long Id { get; set; }
    public string Name { get; set; }
    public long BrandId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Model, ModelDto>();
    }
}