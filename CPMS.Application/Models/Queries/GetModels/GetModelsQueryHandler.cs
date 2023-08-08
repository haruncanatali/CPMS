using AutoMapper;
using AutoMapper.QueryableExtensions;
using CPMS.Application.Common.Interfaces;
using CPMS.Application.Models.Queries.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CPMS.Application.Models.Queries.GetModels;

public class GetModelsQueryHandler : IRequestHandler<GetModelsQuery,List<ModelDto>>
{
    private readonly IApplicationContext _context;
    private readonly IMapper _mapper;

    public GetModelsQueryHandler(IApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ModelDto>> Handle(GetModelsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Models
            .Where(c => (request.Name == null || c.Name.ToLower().Contains(request.Name.ToLower())))
            .ProjectTo<ModelDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}