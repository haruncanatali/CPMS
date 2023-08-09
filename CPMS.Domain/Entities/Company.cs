using CPMS.Domain.Base;
using CPMS.Domain.IdentityEntities;

namespace CPMS.Domain.Entities;

public class Company : BaseEntity
{
    public string Name { get; set; }
    public string Address { get; set; }

    public double Lat { get; set; }
    public double Lon { get; set; }

    public List<ParkingLot> ParkingLots { get; set; }
    public List<ParkPrice> ParkPrices { get; set; }
    public List<Setting> Settings { get; set; }
    public List<User> Users { get; set; }
}