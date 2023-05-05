using Core.Entities.Identity;
using Infra.Data.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Core.Interfaces.Identity;
using Infra.Services.Identity;

namespace API.Extensions
{
    public static class IdentityApplicationConfiguration
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services,
            IConfiguration config)
        {
            services.AddDbContext<VacaIdentityDbContext>(opts => {
                opts.UseSqlite(config.GetConnectionString("IdentityCS"));
            });

            services.AddScoped<ITokenService, TokenService>();

            services.AddIdentityCore<AppUser>(cfgs => {
                // Add Configurations
            })
            .AddEntityFrameworkStores<VacaIdentityDbContext>()
            .AddSignInManager<SignInManager<AppUser>>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opts => {
                    opts.TokenValidationParameters = new TokenValidationParameters{
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Token:Key"])),
                        ValidateIssuer = true,
                        ValidIssuer = config["Token:Issuer"],
                        ValidateAudience = false
                    };
                });

            services.AddAuthorization();
        
            return services;
        }
    }
}