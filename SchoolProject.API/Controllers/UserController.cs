using Microsoft.AspNetCore.Mvc;
using SchoolProject.API.Base;
using SchoolProject.Core.Features.Users.Commands.Models;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.API.Controllers
{
    public class UserController : AppControllerBase
    {
        public UserController() { }

        [HttpPost(Router.UserRouting.Create)]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand std)
        {
            var response = await Mediator.Send(std);

            return NewResult(response);
        }
    }
}
