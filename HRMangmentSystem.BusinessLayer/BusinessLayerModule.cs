using HRMangmentSystem.BusinessLayer.IRepository;
using HRMangmentSystem.BusinessLayer.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace HRMangmentSystem.BusinessLayer
{
    public static class BusinessLayerModule
    {
        public static IServiceCollection BusinessLayerModuleDependendcies(this IServiceCollection services)
        {
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IGroupRepository, GroupRepository>();
            return services;
        }

    }
}
