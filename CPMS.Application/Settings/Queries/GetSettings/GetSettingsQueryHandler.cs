using AutoMapper;
using AutoMapper.QueryableExtensions;
using CPMS.Application.Common.Interfaces;
using CPMS.Application.Settings.Queries.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CPMS.Application.Settings.Queries.GetSettings;

public class GetSettingsQueryHandler : IRequestHandler<GetSettingsQuery,List<SettingDto>>
{
    private readonly IApplicationContext _context;
    private readonly IMapper _mapper;

    public GetSettingsQueryHandler(IApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<SettingDto>> Handle(GetSettingsQuery request, CancellationToken cancellationToken)
    {
        return await _context
            .Settings
            .Where(c => (request.CompanyId == null || c.CompanyId == request.CompanyId))
            .ProjectTo<SettingDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}