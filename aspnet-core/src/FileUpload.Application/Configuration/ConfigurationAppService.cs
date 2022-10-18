using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using FileUpload.Configuration.Dto;

namespace FileUpload.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : FileUploadAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
