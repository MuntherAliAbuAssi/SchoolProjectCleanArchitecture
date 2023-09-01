using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SchoolProject.Data.Helpers;
using SchoolProject.Data.Models.Identity;
using SchoolProject.Infrastructure.Abstract;
using SchoolProject.Service.Abstracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SchoolProject.Service.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        #region Feilds
        private readonly JwtSettings _jwtSettings;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly UserManager<User> _userManager;
        #endregion
        #region Constractors
        public AuthenticationService(UserManager<User> userManager, IRefreshTokenRepository refreshTokenRepository, JwtSettings jwtSettings)
        {
            _userManager = userManager;
            _refreshTokenRepository = refreshTokenRepository;
            _jwtSettings = jwtSettings;
        }
        #endregion
        #region Handle Function 
        public async Task<JwtAuthResult> GetGWTTokenAsync(User user)
        {
            var (jwtToken, accessToken) = GenerateJwtToken(user);
            var getRefreshToken = GetRefreshToken(user.UserName);
            var userRefreshToken = new UserRefreshToken
            {
                CreatedAt = DateTime.Now,
                ExpiredAt = DateTime.Now.AddDays(_jwtSettings.RefreshTokenExpireDate),
                UserId = user.Id,
                IsRevoked = false,
                IsUsed = true,
                JwtId = jwtToken.Id,
                RefreshToken = getRefreshToken.RefreshTokenString,
                Token = accessToken,

            };
            await _refreshTokenRepository.AddAsync(userRefreshToken);

            var result = new JwtAuthResult
            {
                AccessToken = accessToken,
                RefreshToken = getRefreshToken,

            };
            return result;
        }
        public async Task<JwtAuthResult> GetRefreshTokenAsync(User user, JwtSecurityToken jwtToken, string refreshToken, DateTime? expiredAt)
        {

            var (jwtSecurityToken, newToken) = GenerateJwtToken(user);

            var response = new JwtAuthResult();
            response.AccessToken = newToken;

            var refreshTokenResult = new RefreshToken();
            refreshTokenResult.UserName = jwtToken.Claims.FirstOrDefault(x => x.Type == nameof(UserCliamsModel.UserName)).Value;
            refreshTokenResult.RefreshTokenString = refreshToken;
            refreshTokenResult.ExpiredAt = (DateTime)expiredAt;
            response.RefreshToken = refreshTokenResult;
            return response;
        }
        private List<Claim> GetClaims(User user)
        {
            var claims = new List<Claim>()
           {
                new Claim(nameof(UserCliamsModel.UserName),user.UserName),
                new Claim(nameof(UserCliamsModel.Email),user.Email),
                new Claim(nameof(UserCliamsModel.Id),user.Id.ToString()),
                new Claim(nameof(UserCliamsModel.PhoneNumber),user.PhoneNumber)
            };

            return claims;
        }
        private RefreshToken GetRefreshToken(string username)
        {
            var refreshToken = new RefreshToken
            {
                UserName = username,
                RefreshTokenString = GenerateRefreshToken(),
                ExpiredAt = DateTime.Now.AddDays(_jwtSettings.RefreshTokenExpireDate)

            };
            return refreshToken;
        }
        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            var randomNumberGenerate = RandomNumberGenerator.Create();
            randomNumberGenerate.GetBytes(randomNumber);

            return Convert.ToBase64String(randomNumber);
        }
        private (JwtSecurityToken, string) GenerateJwtToken(User user)
        {
            var claims = GetClaims(user);
            var securitykey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256Signature);
            var jwtToken = new JwtSecurityToken(
               _jwtSettings.Issuer,
               _jwtSettings.Audience,
               claims,
               expires: DateTime.UtcNow.AddDays(_jwtSettings.AccessTokenExpireDate),
               signingCredentials: credentials
                );
            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return (jwtToken, accessToken);
        }

        public JwtSecurityToken ReadJwtToken(string accessToken)
        {
            if (string.IsNullOrEmpty(accessToken))
            {
                throw new ArgumentNullException(nameof(accessToken));
            }
            var handler = new JwtSecurityTokenHandler();

            var response = handler.ReadJwtToken(accessToken);

            return response;
        }

        public async Task<string> VaildateToken(string accessToken)
        {
            var handler = new JwtSecurityTokenHandler();

            var parameters = new TokenValidationParameters
            {
                ValidateIssuer = _jwtSettings.ValidateIssuer,
                ValidIssuers = new[] { _jwtSettings.Issuer },
                ValidateIssuerSigningKey = _jwtSettings.ValidateIssuerSigningKey,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)),
                ValidAudience = _jwtSettings.Audience,
                ValidateAudience = _jwtSettings.ValidateAudience,
                ValidateLifetime = _jwtSettings.ValidateLifeTime,
            };
            try
            {
                var validator = handler.ValidateToken(accessToken, parameters, out SecurityToken validatedToken);

                if (validator == null)
                {
                    return "InvalidToken";
                }
                return "NotExpired";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<(string, DateTime?)> VaildateDetails(JwtSecurityToken jwt, string accessToken, string refreshToken)
        {
            if (jwt == null || !jwt.Header.Alg.Equals(SecurityAlgorithms.HmacSha256Signature))
            {

                return ("AlgorithmIsWrong", null);
            }

            if (jwt.ValidTo > DateTime.UtcNow)
            {
                return ("TokenIsNotExpired", null);

            }
            var userId = jwt.Claims.FirstOrDefault(x => x.Type == nameof(UserCliamsModel.Id)).Value;

            var userRefreshToken = await _refreshTokenRepository.GetTableNoTracking().FirstOrDefaultAsync(x => x.Token == accessToken &&
                                                                     x.RefreshToken == refreshToken &&
                                                                     x.UserId == int.Parse(userId));
            if (userRefreshToken == null)
            {
                return ("RefreshTokenIsNotFound", null);
            }

            if (userRefreshToken.ExpiredAt < DateTime.UtcNow)
            {
                userRefreshToken.IsRevoked = true;
                userRefreshToken.IsUsed = false;

                await _refreshTokenRepository.UpdateAsync(userRefreshToken);

                return ("RefreshTokenIsExpired", null);
            }
            var expiredAt = userRefreshToken.ExpiredAt;
            return (userId, expiredAt);
        }



        #endregion
    }
}
