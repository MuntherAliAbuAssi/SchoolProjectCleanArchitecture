using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.API.Base;
using SchoolProject.Core.Features.Authentication.Commonds.Models;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.API.Controllers
{
    public class AuthenticationController : AppControllerBase
    {
        [HttpPost(Router.LoginRouting.Login)]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginCommand user)
        {
            var response = await Mediator.Send(user);

            return NewResult(response);
        }
    }
}
