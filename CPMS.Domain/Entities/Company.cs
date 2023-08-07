using CPMS.Domain.Base;
using CPMS.Domain.IdentityEntities;

namespace CPMS.Domain.Entities;

public class Company : BaseEntity
{
    public string Name { get; set; }

    public List<User> Users { get; set; }
}