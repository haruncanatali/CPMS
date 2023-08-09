using CPMS.Domain.Base;
using CPMS.Domain.Enums;

namespace CPMS.Domain.Entities;

public class Setting : BaseEntity
{
    public SettingType SettingType { get; set; }
    public string Value { get; set; }

    public long CompanyId { get; set; }

    public Company Company { get; set; }
}