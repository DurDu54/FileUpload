using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using FileUpload.EntityFrameworkCore;
using FileUpload.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace FileUpload.Web.Tests
{
    [DependsOn(
        typeof(FileUploadWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class FileUploadWebTestModule : AbpModule
    {
        public FileUploadWebTestModule(FileUploadEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(FileUploadWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(FileUploadWebMvcModule).Assembly);
        }
    }
}