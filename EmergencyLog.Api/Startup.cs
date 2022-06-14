using EmergencyLog.Api.Extensions;
using EmergencyLog.Api.Middleware;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddMicrosoftIdentityWebApi(_configuration.GetSection("AzureAd"));

            services.AddControllers(opt =>
                {
                    // this ensures every endpoint in our API requires authentication unless we tell it otherwise
                    // so we can remove any [Authorize] attrributes on endpoints, and add an [AllowAnonymous] attribute to endpoints like login and new user etc.
                    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                    opt.Filters.Add(new AuthorizeFilter(policy));
                })
                .AddFluentValidation(config =>
            {
                config.RegisterValidatorsFromAssemblyContaining<Application.Attendance.CreateHandler>();
            })
                // this line below stops an error with nested/cyclic objects in the response
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );

            // tidy up into extension method call into "ApplicationExtension.cs"
            services.AddApplicationServices(_configuration);
            services.AddIdentityServices(_configuration);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // this handles exceptions outside of developer mode and returns a reasonable summary in JSON format for easier handling of the returned information
            app.UseMiddleware<ExceptionMiddleware>(); 

            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage(); // gives a stack trace and thorough error information when run in dev. Not used with the middleware above "app.UseMiddleware<ExceptionMiddleware>();"
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
                // if you'd like to test auth functionality, comment out the 4 lines below and uncomment the bottom line.
                if (env.IsDevelopment())
                    endpoints.MapControllers().WithMetadata(new AllowAnonymousAttribute());
                else
                    endpoints.MapControllers();

                // endpoints.MapControllers(); // this line was disabled and replaced with the above if/else to remove auth from debug mode
            });
        }
    }
}
