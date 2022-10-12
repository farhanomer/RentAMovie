using RentAModel.DataAccess.Repositories;
using RentAModel.DataAccess.Repositories.IRepositories;
using RentAMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAModel.DataAccess.UnitofWork
{
    public class UnitofWork : IUnitofWork
    {
        private readonly RentAMovieDbCotext _context;
        private IGenericRepository<Actor> _actorRepository;
        private IGenericRepository<ActorPhoto> _actorPhotoRepository;
        private IGenericRepository<City> _cityRepository;
        private IGenericRepository<Genre> _genreRepository;
        private IGenericRepository<ImageGallery> _imageGalleryRepository;
        private IGenericRepository<Member> _memberRepository;
        private IGenericRepository<MemberCreditCard> _memberCreditCardRepository;
        private IGenericRepository<Movie> _movieRepository;
        private IGenericRepository<MovieCharacter> _movieCharacterRepository;
        private IGenericRepository<MovieCopy> _movieCopyRepository;
        private IGenericRepository<MoviePhoto> _moviePhotoRepository;
        private IGenericRepository<MovieRent> _movieRentRepository;
        private IGenericRepository<MovieRental> _movieRentalRepository;
        private IGenericRepository<MovieRole> _movieRoleRepository;
        public UnitofWork(RentAMovieDbCotext context)
        {
            _context = context;
        }
        public IGenericRepository<Actor> ActorRepository => _actorRepository ??= new GenericRepository<Actor>(_context);

        public IGenericRepository<ActorPhoto> ActorPhotoRepository => _actorPhotoRepository ??= new GenericRepository<ActorPhoto>(_context);

        public IGenericRepository<City> CityRepository => _cityRepository ??= new GenericRepository<City>(_context);

        public IGenericRepository<Genre> GenreRepository => _genreRepository ??= new GenericRepository<Genre>(_context);

        public IGenericRepository<ImageGallery> ImageGalleryRepository => _imageGalleryRepository ??= new GenericRepository<ImageGallery>(_context);

        public IGenericRepository<Member> MemberRepository => _memberRepository ??= new GenericRepository<Member>(_context);

        public IGenericRepository<MemberCreditCard> MemberCreditCardRepository => _memberCreditCardRepository ??= new GenericRepository<MemberCreditCard>(_context);

        public IGenericRepository<Movie> MovieRepository => _movieRepository ??= new GenericRepository<Movie>(_context);

        public IGenericRepository<MovieCharacter> MovieCharacterRepository => _movieCharacterRepository ??= new GenericRepository<MovieCharacter>(_context);

        public IGenericRepository<MovieCopy> MovieCopyRepository => _movieCopyRepository ??= new GenericRepository<MovieCopy>(_context);

        public IGenericRepository<MoviePhoto> MoviePhotoRepository => _moviePhotoRepository ??= new GenericRepository<MoviePhoto>(_context);

        public IGenericRepository<MovieRent> MovieRentRepository => _movieRentRepository ??= new GenericRepository<MovieRent>(_context);

        public IGenericRepository<MovieRental> MovieRentalRepository => _movieRentalRepository ??= new GenericRepository<MovieRental>(_context);

        public IGenericRepository<MovieRole> MovieRoleRepository => _movieRoleRepository ??= new GenericRepository<MovieRole>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
