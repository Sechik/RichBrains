using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RichBrains.Data.Context;
using RichBrains.Data.Interfaces;
using RichBrains.Data.Repository;
using RichBrains.Logic.AutoMapperProfiles;
using RichBrains.Logic.Interfaces;
using RichBrains.Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
