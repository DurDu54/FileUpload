using Abp.Application.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUpload.FileUpload
{
    public interface IFileUploadService : IApplicationService { }
    public class FileUploadService:IFileUploadService
    {
        private IWebHostEnvironment _webHostEnvironment;
        public FileUploadService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        private string PathOnayla()
        {
            
                var Current = Directory.GetCurrentDirectory();
                var path = Path.Combine(Current, @"wwwroot\Files\");
                return path;
            
            
        }
        public async Task DeleteAsync( string fileName)
        {
            var Current = Directory.GetCurrentDirectory();
            var path = Path.Combine(Current, @"wwwroot\");
            File.Delete($"{path}\\{fileName}");
        }
           

        public List<string> GetFiles()
        {
            var newPath = PathOnayla(); 
            DirectoryInfo directory = new(newPath);
            var deneme = directory.GetFiles().Select(f => f.Name).ToList();
            List<string> filePaths = new List<string>();
            foreach (var file in deneme)
            {
                filePaths.Add(Path.Combine(@"Files\", file));
            }
            return filePaths;
        }

        public bool HasFile( string fileName)
            => File.Exists($"{PathOnayla()}\\{fileName}");

        public async Task<List<(string fileName, string path)>> UploadAsync(IFormFileCollection files)
        {
            var newPath = PathOnayla();
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, newPath);
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }
            List<(string fileName, string newPath)> datas = new();
            foreach (IFormFile file in files)
            {
                await CopyFileAsync($"{uploadPath}\\{file.FileName} ", file);
                datas.Add((file.Name, $"{newPath}\\{file.FileName}"));
            }
            return datas;
        }

        async Task<bool> CopyFileAsync(string path, IFormFile file)
        {
            try
            {
                await using FileStream fileStream = new(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);
                await file.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
                return true;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
