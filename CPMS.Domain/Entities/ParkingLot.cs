using CPMS.Domain.Base;
using CPMS.Domain.Enums;

namespace CPMS.Domain.Entities;

public class ParkingLot : BaseEntity
{
    public string Name { get; set; }
    public VehicleType VehicleType { get; set; }

    public long CompanyId { get; set; }

    public Company Company { get; set; }
    public List<ParkingService> ParkingServices { get; set; }
}