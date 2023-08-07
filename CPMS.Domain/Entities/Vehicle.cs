using CPMS.Domain.Base;

namespace CPMS.Domain.Entities;

public class Vehicle : BaseEntity
{
    public string Plate { get; set; }
    public string Color { get; set; }
    public bool LPG { get; set; }
    public string VehiclePhoto { get; set; }

    public long CustomerId { get; set; }
    public long ModelId { get; set; }

    public Customer Customer { get; set; }
    public Model Model { get; set; }
}