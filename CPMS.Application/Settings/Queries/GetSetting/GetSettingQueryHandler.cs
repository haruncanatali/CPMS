using AutoMapper;
using AutoMapper.QueryableExtensions;
using CPMS.Application.Common.Interfaces;
using CPMS.Application.Settings.Queries.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CPMS.Application.Settings.Queries.GetSetting;

public class GetSettingQueryHandler : IRequestHandler<GetSettingQuery,SettingDto>
{
    private readonly IApplicationContext _context;
    private readonly IMapper _mapper;

    public GetSettingQueryHandler(IApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<SettingDto> Handle(GetSettingQuery request, CancellationToken cancellationToken)
    {
        return await _context
            .Settings
            .Where(c => c.Id == request.Id)
            .ProjectTo<SettingDto>(_mapper.ConfigurationProvider)
            .FirstAsync(cancellationToken);
    }
}