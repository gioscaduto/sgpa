namespace Sgpa.Api.Configuration
{
    public static class ApiConfig
    {
        public static IServiceCollection AddApiConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();

            return services;
        }

        public static IApplicationBuilder UseApiConfiguration(this WebApplication app)
        {
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthorization();
            app.UseRouting();
            app.MapControllers();

            app.MapFallbackToFile("index.html"); ;

            return app;
        }
    }
}
