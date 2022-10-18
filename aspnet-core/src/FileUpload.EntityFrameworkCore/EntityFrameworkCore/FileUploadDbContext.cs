using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using FileUpload.Authorization.Roles;
using FileUpload.Authorization.Users;
using FileUpload.MultiTenancy;

namespace FileUpload.EntityFrameworkCore
{
    public class FileUploadDbContext : AbpZeroDbContext<Tenant, Role, User, FileUploadDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public FileUploadDbContext(DbContextOptions<FileUploadDbContext> options)
            : base(options)
        {
        }
    }
}
