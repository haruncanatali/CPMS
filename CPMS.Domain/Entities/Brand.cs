using CPMS.Domain.Base;

namespace CPMS.Domain.Entities;

public class Brand : BaseEntity
{
    public string Name { get; set; }

    public List<Model> Models { get; set; }
}