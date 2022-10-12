using RentAMovie.DTO;

namespace RentAMovie.Services.Interfaces
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(SignInDTO signInDTO);
        Task<string> CreateToken();
    }
}