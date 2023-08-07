using CPMS.Domain.Base;
using CPMS.Domain.Enums;

namespace CPMS.Domain.Entities;

public class Customer : BaseEntity
{
    public string Email { get; set; }
    public string Password { get; set; }
    
    public string Name { get; set; }
    public string Surname { get; set; }
    public string IdentificationNumber { get; set; }
    public string DriverLicenseNumber { get; set; }
    public string ProfilePhoto { get; set; }
    public Gender Gender { get; set; }

    public List<Vehicle> Vehicles { get; set; }
}