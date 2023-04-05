using Imperial_Metric.Application.Interfaces;
using Imperial_Metric.Infrastructure.Context;
using Imperial_Metric.Infrastructure.Repositories;
using Imperial_Metric.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Imperial_Metric.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            
            var useInMemoryDatabase = configuration.GetSection("UseInMemoryDatabase").Value;
            if (Convert.ToBoolean(useInMemoryDatabase))
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("ApplicationDb"));
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(
                   configuration.GetConnectionString("DefaultConnection"),
                   b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
                   
           
                );
                
            }

            #region Repositories

            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddTransient<IDateTimeService, DateTimeService>();
            #endregion Repositories
        }
    }
}