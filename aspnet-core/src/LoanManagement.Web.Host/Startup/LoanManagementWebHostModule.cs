using Abp.Modules;
using Abp.Reflection.Extensions;
using LoanManagement.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace LoanManagement.Web.Host.Startup
{
    [DependsOn(
       typeof(LoanManagementWebCoreModule))]
    public class LoanManagementWebHostModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public LoanManagementWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LoanManagementWebHostModule).GetAssembly());
        }
    }
}
