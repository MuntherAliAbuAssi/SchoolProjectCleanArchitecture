using MediatR;
using SchoolProject.Core.Basies;

namespace SchoolProject.Core.Features.Authentication.Commonds.Models
{
    public class LoginCommand : IRequest<Response<string>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
