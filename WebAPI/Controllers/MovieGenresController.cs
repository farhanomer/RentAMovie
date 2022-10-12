using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentAModel.DataAccess.UnitofWork;
using RentAMovie.DTO;

namespace RentAMovie.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieGenresController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IUnitofWork _unitofWork;
        private readonly IMapper _mapper;
        public MovieGenresController(ILogger<MovieGenresController> logger, IUnitofWork unitofWork, IMapper mapper)
        {
            _logger=logger;
            _mapper=mapper;
            _unitofWork=unitofWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetGenres()
        {
            try
            {
                List<string> includes = new List<string>();
                includes.Add("Movies");
                var genres=await _unitofWork.GenreRepository.GetAll(includes:includes);
                var results = _mapper.Map<IList<GenreDTO>>(genres);
                return Ok(results);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"An error occured. {typeof(MovieGenresController)}");
                return StatusCode(500, "An error occured. Please try again later.");
            }
        }
    }
}
