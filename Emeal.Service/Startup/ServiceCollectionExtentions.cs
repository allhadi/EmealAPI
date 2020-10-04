using AutoMapper;
using Emeal.EFCore.Data;
using Emeal.EFCore.Models;
using Emeal.Service.Abstract;
using Emeal.Service.Concrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using URF.Core.Abstractions;
using URF.Core.Abstractions.Trackable;
using URF.Core.EF;
using URF.Core.EF.Trackable;

namespace Emeal.Service.Startup
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services) 
        { 
            RegisterServices(services); return services; 
        }

        private static void RegisterServices(IServiceCollection services)
        {
            // Add Auto Mapper services             
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped<DbContext, EmealContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //Trackable Repository
            services.AddScoped<ITrackableRepository<User>, TrackableRepository<User>>();
            //Services             
            services.AddScoped<IUserService, UserService>();
        }
    }
}
