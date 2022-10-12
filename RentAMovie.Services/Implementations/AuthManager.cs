using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RentAMovie.DTO;
using RentAMovie.Models;
using RentAMovie.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RentAMovie.Services.Implementations
{
    public class AuthManager : IAuthManager
    {
        private readonly UserManager<Member> _userManager;
        private readonly IConfiguration _configuration;
        private Member _user; 
        public AuthManager(UserManager<Member> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }
        public async Task<string> CreateToken()
        {
            var signInCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var token = GenerateTokenOptions(signInCredentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JWT");
            var expireTime = DateTime.Now.AddMinutes(Convert.ToInt32(jwtSettings.GetSection("LifeTime").Value));
            var token = new JwtSecurityToken(
                issuer: jwtSettings.GetSection("Issuer").Value,
                claims: claims,
                signingCredentials: signingCredentials,
                expires: expireTime,
                audience:null
                ); 
            
            return token;
        }

        private async Task<List<Claim>> GetClaims()
        {
           var claims = new List<Claim>()
           {
               new Claim(ClaimTypes.Name, _user.UserName )
           };
            var roles = await _userManager.GetRolesAsync(_user);
            foreach(var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = _configuration.GetSection("JWT").GetSection("Key").Value;
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        public async Task<bool> ValidateUser(SignInDTO signInDTO)
        {
            _user = await _userManager.FindByNameAsync(signInDTO.Email);
            return !(_user == null || !await _userManager.CheckPasswordAsync(_user, signInDTO.Password));
        }
    }
}
