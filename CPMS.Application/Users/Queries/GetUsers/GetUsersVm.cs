
using CPMS.Application.Users.Queries.Dtos;

namespace CPMS.Application.Users.Queries.GetUsers;

public class GetUsersVm
{
    public List<UserDto> Users { get; set; }
    public int CurrentPage { get; set; }
    public int PageCount { get; set; }
    public bool Next { get; set; }
    public bool Previous { get; set; }
}