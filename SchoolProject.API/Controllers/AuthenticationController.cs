using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.API.Base;
using SchoolProject.Core.Features.Authentication.Commonds.Models;
using SchoolProject.Core.Features.Authentication.Queries.Models;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.API.Controllers
{
    public class AuthenticationController : AppControllerBase
    {
        [HttpPost(Router.AuthenticationRouting.Login)]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromForm] LoginCommand user)
        {
            var response = await Mediator.Send(user);

            return NewResult(response);
        }
        [HttpPost(Router.AuthenticationRouting.RefreshToken)]
        [AllowAnonymous]
        public async Task<IActionResult> RefreshToken([FromForm] RefreshTokenCommand user)
        {
            var response = await Mediator.Send(user);

            return NewResult(response);
        }
        [HttpPost(Router.AuthenticationRouting.VaildateToken)]
        [AllowAnonymous]
        public async Task<IActionResult> Vaildate([FromForm] AuthorizeUserQuery user)
        {
            var response = await Mediator.Send(user);

            return NewResult(response);
        }
    }
}
