using AutoMapper;
using CPMS.Application.Users.Queries.Dtos;
using CPMS.Domain.IdentityEntities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CPMS.Application.Users.Queries.GetUser;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery,UserDto>
{
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;

    public GetUserQueryHandler(UserManager<User> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        UserDto result = null;

        User? user = await _userManager.Users
            .Where(c=>c.Id == request.Id)
            .Include(c=>c.Company)
            .FirstAsync(cancellationToken);

        if (user != null)
        {
            result = _mapper.Map<UserDto>(user);
        }

        return result;
    }
}