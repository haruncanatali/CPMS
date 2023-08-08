using CPMS.Application.Models.Queries.Dtos;
using MediatR;

namespace CPMS.Application.Models.Queries.GetModel;

public class GetModelQuery : IRequest<ModelDto>
{
    public long Id { get; set; }
}