using CPMS.Application.Models.Queries.Dtos;
using MediatR;

namespace CPMS.Application.Models.Queries.GetModels;

public class GetModelsQuery : IRequest<List<ModelDto>>
{
    public string? Name { get; set; }
}