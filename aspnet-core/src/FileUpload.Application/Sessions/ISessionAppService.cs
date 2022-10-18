using System.Threading.Tasks;
using Abp.Application.Services;
using FileUpload.Sessions.Dto;

namespace FileUpload.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
