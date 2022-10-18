using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using FileUpload.Configuration;

namespace FileUpload.Web.Host.Startup
{
    [DependsOn(
       typeof(FileUploadWebCoreModule))]
    public class FileUploadWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public FileUploadWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(FileUploadWebHostModule).GetAssembly());
        }
    }
}
