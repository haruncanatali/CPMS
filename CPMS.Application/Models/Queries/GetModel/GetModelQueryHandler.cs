using AutoMapper;
using AutoMapper.QueryableExtensions;
using CPMS.Application.Common.Interfaces;
using CPMS.Application.Models.Queries.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CPMS.Application.Models.Queries.GetModel;

public class GetModelQueryHandler : IRequestHandler<GetModelQuery,ModelDto>
{
    private readonly IApplicationContext _context;
    private readonly IMapper _mapper;

    public GetModelQueryHandler(IApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ModelDto> Handle(GetModelQuery request, CancellationToken cancellationToken)
    {
        return await _context.Models
            .Where(c => c.Id == request.Id)
            .ProjectTo<ModelDto>(_mapper.ConfigurationProvider)
            .FirstAsync(cancellationToken);
    }
}