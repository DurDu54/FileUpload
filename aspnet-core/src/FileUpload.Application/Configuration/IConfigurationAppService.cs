using System.Threading.Tasks;
using FileUpload.Configuration.Dto;

namespace FileUpload.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
