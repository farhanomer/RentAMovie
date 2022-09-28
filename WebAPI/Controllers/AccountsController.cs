using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RentAModel.DataAccess.UnitofWork;
using RentAMovie.Models;
using RentAMovieDTO;

namespace RentAMovie.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<AccountsController> _logger;
        private readonly UserManager<Member> _userManager;
        private readonly IUnitofWork _unitofWork;
        public AccountsController(IMapper mapper, ILogger<AccountsController> logger, UserManager<Member> userManager, IUnitofWork unitofWork)
        {
            _mapper = mapper;
            _logger = logger;
            _userManager = userManager;
            _unitofWork = unitofWork;
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
        {
            _logger.LogInformation($"Registration Attempt form {registerDTO.Email}");

            if (ModelState.IsValid)
            {
                try
                {
                    
                    var member= _mapper.Map<Member>(registerDTO);
                    member.UserName = registerDTO.Email;
                    member.City =await _unitofWork.CityRepository.GetById(registerDTO.CityId);
                    var result=await _userManager.CreateAsync(member,registerDTO.Password);
                    if (!result.Succeeded)
                    {
                        foreach(var error in result.Errors)
                        {
                            ModelState.AddModelError(error.Code, error.Description);
                        }
                        return BadRequest(ModelState);
                    }
                    await _userManager.AddToRoleAsync(member, registerDTO.Role);
                    return Accepted();
                }
                catch(Exception ex)
                {
                    _logger.LogError(ex, $"Something went wrong in {nameof(Register)}");
                    return Problem($"Something went wrong in {nameof(Register)}", statusCode: 500);
                }
            }
            return BadRequest();
            
        }
        //[HttpPost]
        //[Route("Login")]
        //public async Task<IActionResult> Login([FromBody] SignInDTO signInDTO)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            var result = await _signInManager.PasswordSignInAsync(signInDTO.Email, signInDTO.Password, false, false);
        //            if (result.Succeeded)
        //            {
        //                return Accepted();
        //            }
        //            return Unauthorized(signInDTO);
        //        }
        //        catch(Exception ex)
        //        {
        //            _logger.LogError(ex, "An error has been occured while singing in user");
        //            return StatusCode(500, "An error occured while signing in user");
        //        }
        //    }
        //    return Problem("", statusCode: 500);
        //}
    }
}
