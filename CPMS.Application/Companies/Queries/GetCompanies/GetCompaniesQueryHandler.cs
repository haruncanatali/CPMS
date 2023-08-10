using AutoMapper;
using AutoMapper.QueryableExtensions;
using CPMS.Application.Common.Interfaces;
using CPMS.Application.Companies.Queries.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CPMS.Application.Companies.Queries.GetCompanies;

public class GetCompaniesQueryHandler : IRequestHandler<GetCompaniesQuery,List<CompanyDto>>
{
    private readonly IApplicationContext _context;
    private readonly IMapper _mapper;

    public GetCompaniesQueryHandler(IApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<CompanyDto>> Handle(GetCompaniesQuery request, CancellationToken cancellationToken)
    {
        return await _context.Companies
            .Where(c => (request.Name == null || c.Name.ToLower().Contains(request.Name.ToLower())))
            .Include(c => c.Users)
            .Include(c=>c.ParkingServices)
            .Include(c=>c.ParkPrices)
            .Include(c=>c.ParkingLots)
            .Include(c=>c.Settings)
            .ProjectTo<CompanyDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}