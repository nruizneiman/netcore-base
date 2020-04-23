using Microsoft.Extensions.DependencyInjection;
using SP.Domain.Base.IRepository;
using SP.Domain.Base.IUnitOfWork;
using SP.Infrastructure.Base.Repository;
using SP.Infrastructure.Base.UnitOfWork;

namespace SP.Application.IOC
{
    public static class IoC
    {
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            return services;
        }
    }
}
