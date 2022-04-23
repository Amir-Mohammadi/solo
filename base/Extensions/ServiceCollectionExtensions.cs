


using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Solo.Base.Data;

namespace Solo.Base.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddContext(this IServiceCollection services , IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("SqlServer"));
            });
        }
    }
}