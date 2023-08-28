using Microsoft.IdentityModel.Tokens;
using SchoolProject.Data.Helpers;
using SchoolProject.Data.Models.Identity;
using SchoolProject.Service.Abstracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SchoolProject.Service.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        #region Feilds
        private readonly JwtSettings _jwtSettings;
        #endregion
        #region Constractors
        public AuthenticationService(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }
        #endregion
        #region Handle Function 
        public Task<string> GetGWTToken(User user)
        {
            var claims = new[]
           {
                new Claim(nameof(UserCliamsModel.UserName),user.UserName),
                new Claim(nameof(UserCliamsModel.Email),user.Email),
                new Claim(nameof(UserCliamsModel.Id),user.Id.ToString()),
                new Claim(nameof(UserCliamsModel.PhoneNumber),user.PhoneNumber)
            };
            var securitykey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(
               _jwtSettings.Issuer,
               _jwtSettings.Audience,
               claims,
               expires: DateTime.UtcNow.AddDays(2),
               signingCredentials: credentials
                );

            var accessToken = new JwtSecurityTokenHandler().WriteToken(token);
            return Task.FromResult(accessToken);
        }
        #endregion
    }
}
