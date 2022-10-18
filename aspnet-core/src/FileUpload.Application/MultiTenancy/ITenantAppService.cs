using Abp.Application.Services;
using FileUpload.MultiTenancy.Dto;

namespace FileUpload.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

