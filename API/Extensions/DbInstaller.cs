using DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace API.Extension
{
    public static class DbInstaller
    {
        public static IServiceCollection InstallDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MysqlConnection");
            services.AddDbContext<SoftServeSupportContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
            return services;
        }
    }
}
