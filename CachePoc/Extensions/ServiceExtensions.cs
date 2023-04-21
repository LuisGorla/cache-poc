using CachePoc.Context;
using Microsoft.EntityFrameworkCore;

namespace CachePoc.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            //when webapp deployed change it to WithOrigins("http://www.whatever.com")
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .WithMethods("POST", "GET")
                    .AllowAnyHeader());
            });
        }

        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {
            });
        }

        public static void ConfigureSqlServerContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["ConnectionString:EmployeeDB"];
            services.AddDbContext<EmployeeContext>(opts => opts.UseSqlServer(connectionString));
        }


    }
}