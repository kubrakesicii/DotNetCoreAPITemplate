namespace API.Extension
{
    public static class ServiceInstaller
    {
        public static IServiceCollection InstallServices(this IServiceCollection services)
        {
            // Add services to the container.
            //services.AddScoped<IServiceCollection, Service>();
            return services;
        }
    }
}
