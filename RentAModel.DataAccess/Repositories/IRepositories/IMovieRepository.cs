using RentAMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAModel.DataAccess.Repositories.IRepositories
{
    public interface IMovieRepository:IGenericRepository<Movie>
    {
       Task<IEnumerable<Movie>> GetAllMovies();
    }
}
