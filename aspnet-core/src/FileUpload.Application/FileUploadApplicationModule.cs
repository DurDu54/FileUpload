using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using FileUpload.Authorization;

namespace FileUpload
{
    [DependsOn(
        typeof(FileUploadCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class FileUploadApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<FileUploadAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(FileUploadApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
