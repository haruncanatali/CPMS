using CPMS.Application.Brands.Queries.Dtos;
using MediatR;

namespace CPMS.Application.Brands.Queries.GetBrands;

public class GetBrandsQuery : IRequest<List<BrandDto>>
{
    public string? Name { get; set; }
}