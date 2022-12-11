using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text.Json;

namespace Sgpa.Api.Configuration
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.OperationFilter<SwaggerDefaultValues>();

                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Sgpa API",
                    Contact = new OpenApiContact() { Name = "Sgpa", Email = "sgpa.company@gmail.com" }
                });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Enter the JWT token this way: Bearer {your token}",
                    Name = "Authorization",
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {
            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                    }
                });

            return app;
        }

        public class SwaggerDefaultValues : IOperationFilter
        {
            public void Apply(OpenApiOperation operation, OperationFilterContext context)
            {
                var apiDescription = context.ApiDescription;

                operation.Deprecated |= apiDescription.IsDeprecated();

                foreach (var responseType in context.ApiDescription.SupportedResponseTypes)
                {
                    var responseKey = responseType.IsDefaultResponse ? "default" : responseType.StatusCode.ToString();
                    var response = operation.Responses[responseKey];

                    foreach (var contentType in response.Content.Keys)
                        if (responseType.ApiResponseFormats.All(x => x.MediaType != contentType))
                            response.Content.Remove(contentType);
                }

                if (operation.Parameters == null)
                    return;

                foreach (var parameter in operation.Parameters)
                {
                    var description = apiDescription.ParameterDescriptions.First(p => p.Name == parameter.Name);

                    parameter.Description ??= description.ModelMetadata.Description;

                    if (parameter.Schema.Default == null && description.DefaultValue != null)
                    {
                        var json = JsonSerializer.Serialize(description.DefaultValue, description.ModelMetadata.ModelType);
                        parameter.Schema.Default = OpenApiAnyFactory.CreateFromJson(json);
                    }

                    parameter.Required |= description.IsRequired;
                }
            }
        }
    }
}
