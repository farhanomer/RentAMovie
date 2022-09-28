using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RentAModel.DataAccess.UnitofWork;
using RentAMovieDTO;
using WebAPI.Controllers;

namespace RentAMovie.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class MoviesController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IUnitofWork _unitofWork;
        private readonly IMapper _mapper;
        public MoviesController(ILogger<MoviesController> logger, IUnitofWork unitofWork, IMapper mapper)
        {
            _logger = logger;
            _unitofWork = unitofWork;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetMvoies()
        {
            try
            {
                List<string> _includes=new List<string>();
                _includes.Add("Genres");
                _includes.Add("MovieCopyList");
                _includes.Add("MovieRentList");
                _includes.Add("MovieCharacterList");
                var movies = await _unitofWork.MovieRepository.GetAll(includes: _includes);
                //var movies = await _unitofWork.MoviesListRepository.GetAllMovies();
                var results = _mapper.Map<IList<MovieDTO>>(movies);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong {nameof(GetMvoies)}");

                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetMvoie(int id)
        {
            try
            {
                List<string> _includes = new List<string>();
                _includes.Add("Genres");
                _includes.Add("MovieCopyList");
                _includes.Add("MovieRentList");
                _includes.Add("MovieCharacterList");
                var movie = await _unitofWork.MoviesListRepository.Find(m=>m.Id==id,includes:_includes);
                var result = _mapper.Map<MovieDTO>(movie);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong {nameof(GetMvoies)}");

                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }

    }
}
