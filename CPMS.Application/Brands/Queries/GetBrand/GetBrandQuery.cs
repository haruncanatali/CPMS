using CPMS.Application.Brands.Queries.Dtos;
using MediatR;

namespace CPMS.Application.Brands.Queries.GetBrand;

public class GetBrandQuery : IRequest<BrandDto>
{
    public long Id { get; set; }
}