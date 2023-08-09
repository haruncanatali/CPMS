using CPMS.Application.Settings.Queries.Dtos;
using MediatR;

namespace CPMS.Application.Settings.Queries.GetSetting;

public class GetSettingQuery : IRequest<SettingDto>
{
    public long Id { get; set; }
}