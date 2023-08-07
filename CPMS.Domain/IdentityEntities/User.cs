using System.Runtime.Serialization;
using CPMS.Domain.Entities;
using CPMS.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace CPMS.Domain.IdentityEntities;

public class User : IdentityUser<long>
{
    public User()
    {
        CreatedAt = DateTime.Now;
    }
    
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ProfilePhoto { get; set; }
    public DateTime Birthdate { get; set; }
    public string Address { get; set; }
    public long IdentificationNumber { get; set; }
    public Gender Gender { get; set; }
    public EntityStatus Status { get; set; }
    
    public string RefreshToken { get; set; }
    public DateTime RefreshTokenExpiredTime { get; set; }

    public long CompanyId { get; set; }

    public DateTime CreatedAt { get; set; }

    public Company Company { get; set; }


    [IgnoreDataMember]
    public string FullName
    {
        get { return $"{FirstName} {LastName}"; }
    }
}