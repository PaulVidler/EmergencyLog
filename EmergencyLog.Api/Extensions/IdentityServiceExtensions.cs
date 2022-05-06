using System.Text;
using EmergencyLog.Api.Services;
using EmergencyLog.Domain.Entities.Identity;
using EmergencyLog.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace EmergencyLog.Api.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddIdentityCore<AppUser>(opt =>
                {
                    opt.Password.RequireNonAlphanumeric = true;
                })
            .AddEntityFrameworkStores<DataContext>()
            .AddSignInManager<SignInManager<AppUser>>();

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        // this is where the secret is validated against the server from TokenService.cs -> SymmetricSecurityKey
                        ValidateIssuerSigningKey =
                            true, // this validates the key agaisnt whats on the server, otherwise it would allow any example of a JWT
                        IssuerSigningKey = key,
                        ValidateIssuer = false, // these 2 are set to false, probably not what we'd do in production. Look into this.
                        ValidateAudience = false,
                    };
                });
            services.AddScoped<TokenService>(); // token service is available when we inject into the controller and will be scoped to the lifetime of the http request to the API

            return services;
        }
    }
}
