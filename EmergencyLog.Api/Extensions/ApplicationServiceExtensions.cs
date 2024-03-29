﻿using System.Collections.Generic;
using EmergencyLog.Application.Core;
using EmergencyLog.Application.Interfaces;
using EmergencyLog.Persistence;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure.Security;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using MappingProfiles = EmergencyLog.Application.DTOs.MappingProfiles;

namespace EmergencyLog.Api.Extensions
{
    public static class ApplicationServiceExtensions
    {
        // this class is an extension for startup, where the dependancy injection is happening. Any new services are to be injected here here.
        
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
           
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPIv5", Version = "v1" });
            });
            services.AddDbContext<DataContext>(opt => {
                    opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
                }
            );
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    // policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000"); can get/post/put etc from localhost:3000
                    policy.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
                });
            });
            
            services.AddMediatR(typeof(Application.Attendance.ListHandler).Assembly);
            services.AddAutoMapper(typeof(MappingProfiles).Assembly);
            // this adds the GetUser() method from Infrastructure into DI
            services.AddScoped<IUserAccessor, UserAccessor>();

            return services;
        }
    }
}
