using EmergencyLog.Api.Extensions;
using EmergencyLog.Api.Middleware;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Web;

namespace EmergencyLog.Api
{
    public class Startup
    {
        public IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApi(_configuration.GetSection("AzureAd"));

            services.AddControllers().AddFluentValidation(config =>
            {
                config.RegisterValidatorsFromAssemblyContaining<Application.Attendance.Create>();
                config.RegisterValidatorsFromAssemblyContaining<Application.Addresses.Create>();
                config.RegisterValidatorsFromAssemblyContaining<Application.Clients.Create>();
                config.RegisterValidatorsFromAssemblyContaining<Application.EmergencyContacts.Create>();
                config.RegisterValidatorsFromAssemblyContaining<Application.FireExtinguishers.Create>();
                config.RegisterValidatorsFromAssemblyContaining<Application.FireHoses.Create>();
                config.RegisterValidatorsFromAssemblyContaining<Application.Organisations.Create>();
                config.RegisterValidatorsFromAssemblyContaining<Application.Property.Create>();
                config.RegisterValidatorsFromAssemblyContaining<Application.SmokeAlarms.Create>();
            });

            // tidy up into extension method call into "ApplicationExtension.cs"
            services.AddApplicationServices(_configuration);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // app.UseMiddleware<ExceptionMiddleware>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EmergencyLog.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("CorsPolicy"); // use "CorsPolicy" Defined in ApplicationServiceExtensions

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
