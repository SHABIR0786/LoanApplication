using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Castle.MicroKernel.Registration;
using LoanManagement.Configuration;
using LoanManagement.EntityFrameworkCore;
using LoanManagement.Migrator.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace LoanManagement.Migrator
{
    [DependsOn(typeof(LoanManagementEntityFrameworkModule))]
    public class LoanManagementMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public LoanManagementMigratorModule(LoanManagementEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(LoanManagementMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                LoanManagementConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus),
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LoanManagementMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
