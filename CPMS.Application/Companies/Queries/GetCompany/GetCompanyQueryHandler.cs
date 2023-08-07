using AutoMapper;
using AutoMapper.QueryableExtensions;
using CPMS.Application.Common.Interfaces;
using CPMS.Application.Companies.Queries.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CPMS.Application.Companies.Queries.GetCompany;

public class GetCompanyQueryHandler : IRequestHandler<GetCompanyQuery,CompanyDto>
{
    private readonly IApplicationContext _context;
    private readonly IMapper _mapper;

    public GetCompanyQueryHandler(IApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CompanyDto> Handle(GetCompanyQuery request, CancellationToken cancellationToken)
    {
        return await _context.Companies
            .Where(c => c.Id == request.Id)
            .Include(c => c.Users)
            .ProjectTo<CompanyDto>(_mapper.ConfigurationProvider)
            .FirstAsync(cancellationToken);
    }
}