using System.Threading.Tasks;
using LoanManagement.Models.TokenAuth;
using LoanManagement.Web.Controllers;
using Shouldly;
using Xunit;

namespace LoanManagement.Web.Tests.Controllers
{
    public class HomeController_Tests: LoanManagementWebTestBase
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