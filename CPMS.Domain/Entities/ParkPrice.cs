using CPMS.Domain.Base;
using CPMS.Domain.Enums;

namespace CPMS.Domain.Entities;

public class ParkPrice : BaseEntity
{
    public VehicleType VehicleType { get; set; }
    public decimal Price { get; set; }

    public long CompanyId { get; set; }

    public Company Company { get; set; }
}