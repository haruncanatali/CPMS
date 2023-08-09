using CPMS.Application.Common.Mappings;
using CPMS.Domain.Entities;
using CPMS.Domain.Enums;

namespace CPMS.Application.Settings.Queries.Dtos;

public class SettingDto : IMapFrom<Setting>
{
    public long Id { get; set; }
    public SettingType SettingType { get; set; }
    public string Value { get; set; }
    public long CompanyId { get; set; }
}