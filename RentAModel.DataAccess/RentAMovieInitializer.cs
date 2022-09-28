using Microsoft.AspNetCore.Identity;
using RentAMovie.Models;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace RentAModel.DataAccess
{
    public class RentAMovieInitializer
    {
        #region SeedFuctionRegion
        public static async Task SeedData(RentAMovieDbCotext context, UserManager<Member> userManager)
        {

            Member member = null;
            List<Genre> genres = null;
            List<MovieRole> movieRoles = null;
            List<Movie> movies = null;
            City? city = null;
            if (!context.Roles.Any())
            {
                AddMemberRoles(context);
            }
            if (!context.Genres.Any())
            {
                genres = AddGenres(context);
            }
            else
            {
                genres = context.Genres.ToList();
            }
            if (!context.MovieRoles.Any())
            {
                movieRoles = AddMovieRoles(context);
            }
            else
            {
                movieRoles = context.MovieRoles.ToList();
            }
            if (!context.Cities.Any())
            {
                city = AddCity(context);
            }
            else
            {
                city = context.Cities.FirstOrDefault();
            }
            if (!context.Movies.Any())
            {
                movies = AddMovies(context, genres);
            }
            else
            {
                movies = context.Movies.ToList();
            }
            if (!context.MovieRents.Any())
            {
                AddMovieRents(context, movies);
            }
            if (!userManager.Users.Any())
            {
                member = await AddMember(context, city, userManager);
            }
            else
            {
                member = context.Members.FirstOrDefault();
            }
            if (!context.MemberCreditCards.Any())
            {
                AddMemberCreditCard(context, member);
            }
        }
        #endregion

        #region AddingRolesRegion
        public static void AddMemberRoles(RentAMovieDbCotext context)
        {
            IdentityRole role = new IdentityRole();
            role.Name = "Member";
            role.NormalizedName = "Member";

            context.Roles.Add(role);
            context.SaveChanges();
        }
        #endregion

        #region AddGenreRegion
        public static List<Genre> AddGenres(RentAMovieDbCotext context)
        {

            var genres = new List<Genre> {
               new Genre
               {
                   Name="Drama",
               },
               new Genre
               {
                   Name="Adventure",
               },
               new Genre
               {
                   Name="Action",
               },
               new Genre
               {
                   Name="Crime",
               },
            };
            context.Genres.AddRange(genres);
            context.SaveChanges();
            return genres;

        }
        #endregion

        #region AddMovieRolesRegion
        public static List<MovieRole> AddMovieRoles(RentAMovieDbCotext context)
        {

            var roles = new List<MovieRole> {
               new MovieRole
               {
                   Name="Director",
               },
               new MovieRole
               {
                   Name="Actor",
               },
               new MovieRole
               {
                   Name="Producer",
               },

            };
            context.MovieRoles.AddRange(roles);
            context.SaveChanges();
            return roles;

        }
        #endregion

        #region AddMoviesRegion
        public static List<Movie> AddMovies(RentAMovieDbCotext context, List<Genre> genres)
        {

            var movies = new List<Movie>();
            Movie movie1 = new Movie
            {
                Name = "The Shawshank Redemption",
                ReleaseDate = new DateTime(1994, 1, 1),
                ImdbRating = 9.3M,
                TotalRatings = 260000000,
                MinAgeLimit = 18,
                Summary = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
                Genres = genres.Where(g => g.Name == "Drama" || g.Name == "Adventure").ToList()
            };
            context.Movies.Add(movie1);
            context.SaveChanges();
            movies.Add(movie1);

            AddMovie1Images(context, movie1);
            var actors1 = AddMovie1Actors(context, movie1);
            AddMovieCharachers(context, movie1, actors1[0], context.MovieRoles.Where(a => a.Name == "Actor").FirstOrDefault(), "Andy Dufresne");
            AddMovieCharachers(context, movie1, actors1[1], context.MovieRoles.Where(a => a.Name == "Actor").FirstOrDefault(), "Ellis Boyd 'Red' Redding");

            Movie movie2 = new Movie
            {
                Name = "The Dark Knight",
                ReleaseDate = new DateTime(2008, 1, 1),
                ImdbRating = 9.0M,
                TotalRatings = 260000000,
                MinAgeLimit = 18,
                Summary = "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.",
                Genres = genres.Where(g => g.Name == "Drama" || g.Name == "Crime" || g.Name == "Action").ToList()
            };
            context.Movies.Add(movie2);
            context.SaveChanges();
            movies.Add(movie2);
            AddMovie1Images(context, movie2);
            var actors2 = AddMovie2Actors(context, movie2);
            AddMovieCharachers(context, movie2, actors2[0], context.MovieRoles.Where(a => a.Name == "Actor").FirstOrDefault(), "Bruce Wayne");
            AddMovieCharachers(context, movie2, actors2[1], context.MovieRoles.Where(a => a.Name == "Actor").FirstOrDefault(), "Joker");

            //adding copies of movies in the inventory
            AddMovieCopies(context, movies);


            return movies;
        }
        #endregion

        #region AddMovie1ImagesRegion
        public static List<ImageGallery> AddMovie1Images(RentAMovieDbCotext context, Movie movie)
        {
            //Shawshank Redemption
            List<ImageGallery> images = new List<ImageGallery>();

            ImageGallery image = new ImageGallery();
            image.Name = movie.Name;
            image.Description = "Image from " + movie.Name;
            image.Path = "https://m.media-amazon.com/images/M/MV5BMDFkYTc0MGEtZmNhMC00ZDIzLWFmNTEtODM1ZmRlYWMwMWFmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_FMjpg_UX1000_.jpg";
            context.ImageGalleries.Add(image);
            context.SaveChanges();

            MoviePhoto moviePhoto = new MoviePhoto();
            moviePhoto.IsDefaultPhoto = true;
            moviePhoto.IsDeleted = false;
            moviePhoto.Movie = movie;
            moviePhoto.Gallery = image;
            context.MoviePhotos.Add(moviePhoto);
            context.SaveChanges();
            images.Add(image);

            return images;
        }
        #endregion

        #region AddMovie2ImagesRegion
        public static void AddMovie2Images(RentAMovieDbCotext context, Movie movie)
        {
            //Dark Knight
            List<ImageGallery> images = new List<ImageGallery>();

            ImageGallery image = new ImageGallery();
            image.Name = movie.Name;
            image.Description = "Image from " + movie.Name;
            image.Path = "https://m.media-amazon.com/images/M/MV5BMTMxNTMwODM0NF5BMl5BanBnXkFtZTcwODAyMTk2Mw@@._V1_.jpg";
            context.ImageGalleries.Add(image);
            context.SaveChanges();

            MoviePhoto moviePhoto = new MoviePhoto();
            moviePhoto.IsDefaultPhoto = true;
            moviePhoto.IsDeleted = false;
            moviePhoto.Movie = movie;
            moviePhoto.Gallery = image;
            context.MoviePhotos.Add(moviePhoto);
            context.SaveChanges();
            images.Add(image);
        }
        #endregion

        #region AddMovieCopiesRegion
        public static bool AddMovieCopies(RentAMovieDbCotext context, List<Movie> movies)
        {
            if (movies == null)
            {
                return false;
            }
            int movieCount = 1;
            foreach (Movie movie in movies)
            {
                for (int i = 0; i <= movieCount; i++)
                {
                    MovieCopy movieCopy = new MovieCopy();
                    movieCopy.MovieTagNumber = Guid.NewGuid();
                    movieCopy.Movie = movie;
                    movieCopy.IsDamaged = false;
                    context.MovieCopies.Add(movieCopy);
                    context.SaveChanges();
                }
                movieCount++;
            }
            return true;
        }
        #endregion

        #region AddCityRegion
        public static City AddCity(RentAMovieDbCotext context)
        {

            var city = new City
            {
                Name = "Jersey City",
            };
            context.Cities.Add(city);
            context.SaveChanges();
            return city;

        }
        #endregion

        #region AddMovieRentsRegion
        public static bool AddMovieRents(RentAMovieDbCotext context, List<Movie> movies)
        {
            if (movies == null)
            {
                return false;
            }
            int movieCount = 1;
            foreach (Movie movie in movies)
            {
                for (int i = 0; i <= movieCount; i++)
                {
                    MovieRent movieRent = new MovieRent();
                    movieRent.ValueDate = DateTime.Now;
                    movieRent.Movie = movie;
                    movieRent.Active = true;
                    movieRent.DailyRent = 10.0m;
                    context.MovieRents.Add(movieRent);
                    context.SaveChanges();
                }
                movieCount++;
            }
            return true;
        }
        #endregion

        #region AddMemberRegion
        public static async Task<Member> AddMember(RentAMovieDbCotext context, City city, UserManager<Member> userManager)
        {
            var member = new Member
            {
                Name = "Farhan Omer",
                Email = "farhanomer@gmail.com",
                Address = "Test Address",
                DateofBirth = DateTime.Now.AddYears(-30),
                PhoneNumber = "732-947-6632",
                City = city,

            };
            await userManager.CreateAsync(member, "Password#12");
            return member;
        }
        #endregion

        #region AddCreditCardRegion
        public static bool AddMemberCreditCard(RentAMovieDbCotext context, Member member)
        {
            string[] creditCardNumbers = { "4012 8888 8888 1881" };

            MemberCreditCard memberCreditCard = new MemberCreditCard();
            memberCreditCard.CardNumber = creditCardNumbers[0];
            memberCreditCard.Member = member;
            context.MemberCreditCards.Add(memberCreditCard);
            context.SaveChanges();

            return true;
        }
        #endregion

        #region AddMovie1ActorsRegion
        public static List<Actor> AddMovie1Actors(RentAMovieDbCotext context, Movie movie)
        {
            List<Actor> actors = new List<Actor>();

            //Tim Robbins
            Actor actor = new Actor();
            ImageGallery image = new ImageGallery();
            ActorPhoto actorPhoto = new ActorPhoto();

            actor.Name = "Tim Robbins";
            actor.DateofBirth = new DateTime(1958, 10, 16);
            actor.DateofDeath = null;
            actor.Summary = "Born in West Covina, California, but raised in New York City, Tim Robbins is the son of former The Highwaymen singer Gil Robbins and actress Mary Robbins (née Bledsoe). Robbins studied drama at UCLA, where he graduated with honors in 1981. That same year, he formed the Actors' Gang theater group, an experimental ensemble that expressed radical political observations through the European avant-garde form of theater.";
            actor.BioDetails = "Born in West Covina, California, but raised in New York City, Tim Robbins is the son of former The Highwaymen singer Gil Robbins and actress Mary Robbins (née Bledsoe). Robbins studied drama at UCLA, where he graduated with honors in 1981. That same year, he formed the Actors' Gang theater group, an experimental ensemble that expressed radical political observations through the European avant-garde form of theater.";
            context.Actors.Add(actor);
            context.SaveChanges();


            image.Name = actor.Name;
            image.Description = "Image from " + actor.Name;
            image.Path = "https://m.media-amazon.com/images/M/MV5BMTI1OTYxNzAxOF5BMl5BanBnXkFtZTYwNTE5ODI4._V1_UY317_CR16,0,214,317_AL_.jpg";
            context.ImageGalleries.Add(image);
            context.SaveChanges();

            actorPhoto.IsDefaultPhoto = true;
            actorPhoto.IsDeleted = false;
            actorPhoto.Actor = actor;
            actorPhoto.Gallery = image;
            context.ActorPhotos.Add(actorPhoto);
            context.SaveChanges();
            actors.Add(actor);


            //Morgan Freeman
            Actor actor1 = new Actor();
            ImageGallery image1 = new ImageGallery();
            ActorPhoto actorPhoto1 = new ActorPhoto();


            actor1.Name = "Morgan Freeman";
            actor1.DateofBirth = new DateTime(1937, 06, 01);
            actor1.DateofDeath = null;
            actor1.Summary = "With an authoritative voice and calm demeanor, this ever popular American actor has grown into one of the most respected figures in modern US cinema. Morgan was born on June 1, 1937 in Memphis, Tennessee, to Mayme Edna (Revere), a teacher, and Morgan Porterfield Freeman, a barber. The young Freeman attended Los Angeles City College before serving several years in the US Air Force as a mechanic between 1955 and 1959. His first dramatic arts exposure was on the stage including appearing in an all-African American production of the exuberant musical Hello, Dolly";
            actor1.BioDetails = "With an authoritative voice and calm demeanor, this ever popular American actor has grown into one of the most respected figures in modern US cinema. Morgan was born on June 1, 1937 in Memphis, Tennessee, to Mayme Edna (Revere), a teacher, and Morgan Porterfield Freeman, a barber. The young Freeman attended Los Angeles City College before serving several years in the US Air Force as a mechanic between 1955 and 1959. His first dramatic arts exposure was on the stage including appearing in an all-African American production of the exuberant musical Hello, Dolly";
            context.Actors.Add(actor1);
            context.SaveChanges();


            image1.Name = actor1.Name;
            image1.Description = "Image from " + actor1.Name;
            image1.Path = "https://m.media-amazon.com/images/M/MV5BMTc0MDMyMzI2OF5BMl5BanBnXkFtZTcwMzM2OTk1MQ@@._V1_UX214_CR0,0,214,317_AL_.jpg";
            context.ImageGalleries.Add(image1);
            context.SaveChanges();

            actorPhoto1.IsDefaultPhoto = true;
            actorPhoto1.IsDeleted = false;
            actorPhoto1.Actor = actor;
            actorPhoto1.Gallery = image1;
            context.ActorPhotos.Add(actorPhoto1);
            context.SaveChanges();
            actors.Add(actor1);
            return actors;
        }
        #endregion

        #region AddMovie2ActorsRegion
        public static List<Actor> AddMovie2Actors(RentAMovieDbCotext context, Movie movie)
        {
            List<Actor> actors = new List<Actor>();
            //Christian Bale
            Actor actor2 = new Actor();
            ImageGallery image2 = new ImageGallery();
            ActorPhoto actorPhoto2 = new ActorPhoto();

            actor2.Name = "Christian Bale";
            actor2.DateofBirth = new DateTime(1974, 01, 30);
            actor2.DateofDeath = null;
            actor2.Summary = "Christian Charles Philip Bale was born in Pembrokeshire, Wales, UK on January 30, 1974, to English parents Jennifer \"Jenny\" (James) and David Bale. His mother was a circus performer and his father, who was born in South Africa, was a commercial pilot. The family lived in different countries throughout Bale's childhood, including England, Portugal";
            actor2.BioDetails = "Christian Charles Philip Bale was born in Pembrokeshire, Wales, UK on January 30, 1974, to English parents Jennifer \"Jenny\" (James) and David Bale. His mother was a circus performer and his father, who was born in South Africa, was a commercial pilot. The family lived in different countries throughout Bale's childhood, including England, Portugal";
            context.Actors.Add(actor2);
            context.SaveChanges();


            image2.Name = actor2.Name;
            image2.Description = "Image from " + actor2.Name;
            image2.Path = "https://m.media-amazon.com/images/M/MV5BMTkxMzk4MjQ4MF5BMl5BanBnXkFtZTcwMzExODQxOA@@._V1_UX214_CR0,0,214,317_AL_.jpg";
            context.ImageGalleries.Add(image2);
            context.SaveChanges();

            actorPhoto2.IsDefaultPhoto = true;
            actorPhoto2.IsDeleted = false;
            actorPhoto2.Actor = actor2;
            actorPhoto2.Gallery = image2;
            context.ActorPhotos.Add(actorPhoto2);
            context.SaveChanges();
            actors.Add(actor2);

            //Heath Ledger
            Actor actor3 = new Actor();
            ImageGallery image3 = new ImageGallery();
            ActorPhoto actorPhoto3 = new ActorPhoto();

            actor3.Name = "Heath Ledger";
            actor3.DateofBirth = new DateTime(1979, 04, 04);
            actor3.DateofDeath = new DateTime(2008, 01, 08);
            actor3.Summary = "When hunky, twenty-year-old heart-throb Heath Ledger first came to the attention of the public in 1999, it was all too easy to tag him as a \"pretty boy\" and an actor of little depth. He spent several years trying desperately to sway this image, but this was a double-edged sword.";
            actor3.BioDetails = "When hunky, twenty-year-old heart-throb Heath Ledger first came to the attention of the public in 1999, it was all too easy to tag him as a \"pretty boy\" and an actor of little depth. He spent several years trying desperately to sway this image, but this was a double-edged sword.";
            context.Actors.Add(actor3);
            context.SaveChanges();

            image3.Name = actor3.Name;
            image3.Description = "Image from " + actor3.Name;
            image3.Path = "https://m.media-amazon.com/images/M/MV5BMTI2NTY0NzA4MF5BMl5BanBnXkFtZTYwMjE1MDE0._V1_UX214_CR0,0,214,317_AL_.jpg";
            context.ImageGalleries.Add(image3);
            context.SaveChanges();

            actorPhoto3.IsDefaultPhoto = true;
            actorPhoto3.IsDeleted = false;
            actorPhoto3.Actor = actor3;
            actorPhoto3.Gallery = image3;
            context.ActorPhotos.Add(actorPhoto3);
            context.SaveChanges();
            actors.Add(actor3);

            return actors;
        }

        #endregion

        #region AddMovieCharacters
        public static void AddMovieCharachers(RentAMovieDbCotext context, Movie movie, Actor actor, MovieRole movieRole, string CharacherName)
        {
            MovieCharacter character = new MovieCharacter();
            character.Name = CharacherName;
            //character.MovieRole
            character.Actor = actor;
            character.Movie = movie;
            character.MovieRole = movieRole;
            context.MovieCharacters.Add(character);
            context.SaveChanges();
        }
        #endregion
    }
}
