using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace FileUpload.EntityFrameworkCore
{
    public static class FileUploadDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<FileUploadDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<FileUploadDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
