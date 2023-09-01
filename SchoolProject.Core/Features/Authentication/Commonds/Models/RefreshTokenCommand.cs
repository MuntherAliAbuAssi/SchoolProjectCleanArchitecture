using MediatR;
using SchoolProject.Core.Basies;
using SchoolProject.Data.Helpers;

namespace SchoolProject.Core.Features.Authentication.Commonds.Models
{
    public class RefreshTokenCommand : IRequest<Response<JwtAuthResult>>
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

    }
}
