using Microsoft.EntityFrameworkCore;
using RentAModel.DataAccess.Repositories.IRepositories;
using RentAMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAModel.DataAccess.Repositories
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository 
    {
        private readonly RentAMovieDbCotext _context;
        public MovieRepository(RentAMovieDbCotext context) : base(context)
        {
            _context = context;
        }

        async Task<IEnumerable<Movie>> IMovieRepository.GetAllMovies()
        {
            var movies= await _context.Movies.Include(m=>m.Genres).Include(m=>m.MovieCopyList).Include(m=>m.MovieCharacterList).Include(m=>m.MovieRentList).ToListAsync();
            return movies;
        }
    }
}
