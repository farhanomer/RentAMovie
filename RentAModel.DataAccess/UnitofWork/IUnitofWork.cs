using RentAModel.DataAccess.Repositories.IRepositories;
using RentAMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAModel.DataAccess.UnitofWork
{
    public interface IUnitofWork : IDisposable
    {
        IGenericRepository<Actor> ActorRepository { get; }
        IGenericRepository<ActorPhoto> ActorPhotoRepository { get; }
        IGenericRepository<City> CityRepository { get; }
        IGenericRepository<Genre> GenreRepository { get; }
        IGenericRepository<ImageGallery> ImageGalleryRepository { get; }
        IGenericRepository<Member> MemberRepository { get; }
        IGenericRepository<MemberCreditCard> MemberCreditCardRepository { get; }
        IGenericRepository<Movie> MovieRepository { get; }
        IGenericRepository<MovieCharacter> MovieCharacterRepository { get; }
        IGenericRepository<MovieCopy> MovieCopyRepository { get; }
        IGenericRepository<MoviePhoto> MoviePhotoRepository { get; }
        IGenericRepository<MovieRent> MovieRentRepository { get; }
        IGenericRepository<MovieRental> MovieRentalRepository { get; }
        IGenericRepository<MovieRole> MovieRoleRepository { get; }
        IMovieRepository MoviesListRepository { get; }
        Task Save();
    }
}
