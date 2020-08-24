using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;

namespace WebApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Web API project draaiplank",
                    Description = "ASP.NET Core Web API for our project (mobiele-ucll). Authentication will be added later",
                    Contact = new OpenApiContact
                    {
                        Name = "Indy Naessens",
                        Email = "indy.naessens@protonmail.com",
                        Url = new Uri("https://github.com/IndyNaessens")
                    },
                });
                
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                c.AddFluentValidationRules();
                c.IncludeXmlComments(xmlPath);
            });

            return services;
        }
    }
}