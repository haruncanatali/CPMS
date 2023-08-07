using CPMS.Domain.Base;

namespace CPMS.Domain.Entities;

public class Model : BaseEntity
{
    public string Name { get; set; }
    public long BrandId { get; set; }

    public Brand Brand { get; set; }
}