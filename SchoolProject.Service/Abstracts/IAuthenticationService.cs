using SchoolProject.Data.Helpers;
using SchoolProject.Data.Models.Identity;
using System.IdentityModel.Tokens.Jwt;

namespace SchoolProject.Service.Abstracts
{
    public interface IAuthenticationService
    {
        public Task<JwtAuthResult> GetGWTTokenAsync(User user);
        public Task<JwtAuthResult> GetRefreshTokenAsync(User user, JwtSecurityToken jwtToken, string refreshToken, DateTime? expiredAt);
        public Task<string> VaildateToken(string accessToken);
        public JwtSecurityToken ReadJwtToken(string accessToken);
        public Task<(string, DateTime?)> VaildateDetails(JwtSecurityToken jwt, string accessToken, string refreshToken);
    }
}
