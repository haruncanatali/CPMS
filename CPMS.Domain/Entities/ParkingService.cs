using CPMS.Domain.Base;

namespace CPMS.Domain.Entities;

public class ParkingService : BaseEntity
{
    public long VehicleId { get; set; }
    public long ParkPriceId { get; set; }
    public long ParkingLotId { get; set; }
    public long CompanyId { get; set; }

    public decimal Total { get; set; }
    public int TotalHour { get; set; }

    public Vehicle Vehicle { get; set; }
    public ParkPrice ParkPrice { get; set; }
    public Company Company { get; set; }
    public ParkingLot ParkingLot { get; set; }
    public List<ServicePrice> ServicePrices { get; set; }
}