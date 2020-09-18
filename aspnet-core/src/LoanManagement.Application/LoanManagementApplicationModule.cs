using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using LoanManagement.Authorization;

namespace LoanManagement
{
    [DependsOn(
        typeof(LoanManagementCoreModule),
        typeof(AbpAutoMapperModule))]
    public class LoanManagementApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<LoanManagementAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(LoanManagementApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
