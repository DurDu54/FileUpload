using System.Threading.Tasks;
using Abp.Application.Services;
using FileUpload.Authorization.Accounts.Dto;

namespace FileUpload.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
