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
        public async Task<IActionResult> Create([FromForm] CreateUserCommand user)
        {
            var response = await Mediator.Send(user);

            return NewResult(response);
        }
        [HttpPut(Router.UserRouting.Update)]
        public async Task<IActionResult> Edit([FromForm] EditUserCommand user)
        {
            var response = await Mediator.Send(user);

            return NewResult(response);
        }
    }
}
