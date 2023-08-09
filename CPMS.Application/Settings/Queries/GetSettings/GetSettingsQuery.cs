using CPMS.Application.Settings.Queries.Dtos;
using MediatR;

namespace CPMS.Application.Settings.Queries.GetSettings;

public class GetSettingsQuery : IRequest<List<SettingDto>>
{
    public long? CompanyId { get; set; }
}