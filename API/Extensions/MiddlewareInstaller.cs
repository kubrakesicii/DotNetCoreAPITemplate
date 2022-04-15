using API.Middlewares;

namespace API.Extensions
{
    public static class MiddlewareInstaller
    {
        public static IApplicationBuilder ConfigureMiddlewares(this IApplicationBuilder app)
        {
            app.UseErrorHandlerMiddleware();
            app.UseImageHandlerMiddleware();
            return app;
        }
    }
}
