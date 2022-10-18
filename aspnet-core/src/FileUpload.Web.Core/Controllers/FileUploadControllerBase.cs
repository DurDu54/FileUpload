using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace FileUpload.Controllers
{
    public abstract class FileUploadControllerBase: AbpController
    {
        protected FileUploadControllerBase()
        {
            LocalizationSourceName = FileUploadConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
