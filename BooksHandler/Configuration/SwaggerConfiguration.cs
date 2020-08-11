using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace BooksHandler.Configuration
{
    public static class SwaggerConfiguration
    {
        public static IApplicationBuilder ConfigureSwagger(this IApplicationBuilder app)
        {
            return app;
        }

        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "My Books API",
                        Version = "v1",
                    });
            });

            return services;
        }
    }
}