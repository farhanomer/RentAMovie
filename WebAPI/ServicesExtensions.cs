using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using RentAModel.DataAccess;
using RentAMovie.Models;
using System.Text;

namespace RentAMovie.WebAPI
{
    public static class ServicesExtensions
    {
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentityCore<Member>(m => m.User.RequireUniqueEmail = true);
            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), services);
            builder.AddEntityFrameworkStores<RentAMovieDbCotext>().AddDefaultTokenProviders();
        }
        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("JWT");
           
            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(o => 
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.GetSection("Issuer").Value,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.GetSection("Key").Value))

                };
            });
        }
    }
}
