using CPMS.Application.Users.Queries.Dtos;
using MediatR;

namespace CPMS.Application.Users.Queries.GetUser;

public class GetUserQuery : IRequest<UserDto>
{
    public long Id { get; set; }
}