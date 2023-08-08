using AutoMapper;
using AutoMapper.QueryableExtensions;
using CPMS.Application.Brands.Queries.Dtos;
using CPMS.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CPMS.Application.Brands.Queries.GetBrand;

public class GetBrandQueryHandler : IRequestHandler<GetBrandQuery,BrandDto>
{
    private readonly IApplicationContext _context;
    private readonly IMapper _mapper;

    public GetBrandQueryHandler(IApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<BrandDto> Handle(GetBrandQuery request, CancellationToken cancellationToken)
    {
        return await _context.Brands
            .Where(c => c.Id == request.Id)
            .Include(c => c.Models)
            .ProjectTo<BrandDto>(_mapper.ConfigurationProvider)
            .FirstAsync(cancellationToken);
    }
}