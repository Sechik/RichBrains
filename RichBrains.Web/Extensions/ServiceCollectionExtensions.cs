using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NSwag;
using RichBrains.Data.Context;
using RichBrains.Data.Interfaces;
using RichBrains.Data.Repository;
using RichBrains.Logic.AutoMapperProfiles;
using RichBrains.Logic.Interfaces;
using RichBrains.Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RichBrains.Web.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        internal static void ConfigureAutoMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new UserProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        internal static void ConfigureDependencyInjection(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<IUserService, UserService>();
        }

        internal static void ConfigureDbContext(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(
                opt =>
                {
                    opt.UseSqlite("Data Source=richbrains.db");
                });
        }

        internal static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerDocument(config =>
            {
                config.Description = "Backend";
                config.Title = "RichBrains";
                config.AddSecurity("JWT Token", Enumerable.Empty<string>(),
                    new OpenApiSecurityScheme()
                    {
                        Type = OpenApiSecuritySchemeType.ApiKey,
                        Name = nameof(Authorization),
                        In = OpenApiSecurityApiKeyLocation.Header,
                        Description = "Copy this into the value field: Bearer {token}"
                    });
            });
        }

    }
}
