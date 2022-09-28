using Microsoft.AspNetCore.Identity;
using RentAModel.DataAccess;
using RentAMovie.Models;

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
    }
}
