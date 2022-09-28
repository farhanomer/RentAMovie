using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentAMovie.Models;

namespace RentAModel.DataAccess
{
    public class RentAMovieDbCotext : IdentityDbContext<Member>
    {
        public RentAMovieDbCotext(DbContextOptions options) : base(options)
        {

        }
        protected void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<ActorPhoto> ActorPhotos { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<ImageGallery> ImageGalleries { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<MemberCreditCard> MemberCreditCards { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieCharacter> MovieCharacters { get; set; }
        public DbSet<MovieCopy> MovieCopies { get; set; }
        public DbSet<MoviePhoto> MoviePhotos { get; set; }
        public DbSet<MovieRent> MovieRents { get; set; }
        public DbSet<MovieRental> MovieRentals { get; set; }
        public DbSet<MovieRole> MovieRoles { get; set; }

    }
}