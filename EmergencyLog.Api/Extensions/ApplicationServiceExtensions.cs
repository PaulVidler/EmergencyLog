using System.Collections.Generic;
using EmergencyLog.Application.Core;
using EmergencyLog.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace EmergencyLog.Api.Extensions
{
    public static class ApplicationServiceExtensions
    {
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
                    policy.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
                });
            });

            services.AddMediatR(typeof(Application.Addresses.List.Handler).Assembly); // the assembly being referenced in the List.Handler class is the arg here
            services.AddMediatR(typeof(Application.Addresses.Create.Handler).Assembly);
            services.AddMediatR(typeof(Application.Addresses.Delete.Handler).Assembly);
            services.AddMediatR(typeof(Application.Addresses.Details.Handler).Assembly);
            services.AddMediatR(typeof(Application.Addresses.Edit.Handler).Assembly);

            services.AddMediatR(typeof(Application.Attendance.List.Handler).Assembly);
            services.AddMediatR(typeof(Application.Attendance.Create.Handler).Assembly);
            services.AddMediatR(typeof(Application.Attendance.Delete.Handler).Assembly);
            services.AddMediatR(typeof(Application.Attendance.Details.Handler).Assembly);
            services.AddMediatR(typeof(Application.Attendance.Edit.Handler).Assembly);

            services.AddMediatR(typeof(Application.Clients.List.Handler).Assembly);
            services.AddMediatR(typeof(Application.Clients.Create.Handler).Assembly);
            services.AddMediatR(typeof(Application.Clients.Delete.Handler).Assembly);
            services.AddMediatR(typeof(Application.Clients.Details.Handler).Assembly);
            services.AddMediatR(typeof(Application.Clients.Edit.Handler).Assembly);

            services.AddMediatR(typeof(Application.EmergencyContacts.List.Handler).Assembly);
            services.AddMediatR(typeof(Application.EmergencyContacts.Create.Handler).Assembly);
            services.AddMediatR(typeof(Application.EmergencyContacts.Delete.Handler).Assembly);
            services.AddMediatR(typeof(Application.EmergencyContacts.Details.Handler).Assembly);
            services.AddMediatR(typeof(Application.EmergencyContacts.Edit.Handler).Assembly);

            services.AddAutoMapper(typeof(MappingProfiles).Assembly);

            return services;
        }
    }
}
