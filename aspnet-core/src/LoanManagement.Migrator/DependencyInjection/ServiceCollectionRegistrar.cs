using Abp.Dependency;
using Castle.Windsor.MsDependencyInjection;
using LoanManagement.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace LoanManagement.Migrator.DependencyInjection
{
    public static class ServiceCollectionRegistrar
    {
        public static void Register(IIocManager iocManager)
        {
            var services = new ServiceCollection();

            IdentityRegistrar.Register(services);

            WindsorRegistrationHelper.CreateServiceProvider(iocManager.IocContainer, services);
        }
    }
}
