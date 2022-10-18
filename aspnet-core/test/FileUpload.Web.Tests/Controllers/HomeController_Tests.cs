using System.Threading.Tasks;
using FileUpload.Models.TokenAuth;
using FileUpload.Web.Controllers;
using Shouldly;
using Xunit;

namespace FileUpload.Web.Tests.Controllers
{
    public class HomeController_Tests: FileUploadWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}