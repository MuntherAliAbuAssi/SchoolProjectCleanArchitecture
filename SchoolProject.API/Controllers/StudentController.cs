using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.API.Base;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.API.Controllers
{
    [Authorize]
    public class StudentController : AppControllerBase
    {

        [HttpGet(Router.StudentRouting.List)]
        public async Task<IActionResult> GetStudentListAsync()
        {
            var response = await Mediator.Send(new GetStudentListQuery());

            return NewResult(response);
        }

        [HttpGet(Router.StudentRouting.Paginated)]
        public async Task<IActionResult> Paginated([FromQuery] GetStudentPaginatedListQuery query)
        {
            var response = await Mediator.Send(query);

            return Ok(response);
        }
        [HttpGet(Router.StudentRouting.GetstudentByID)]
        public async Task<IActionResult> GetStudentByIdAsync([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetStudentByIdQuery(id));

            return NewResult(response);
        }
        [HttpPost(Router.StudentRouting.Create)]
        public async Task<IActionResult> Create([FromBody] CreateStudentCommand std)
        {
            var response = await Mediator.Send(std);

            return NewResult(response);
        }
        [HttpPut(Router.StudentRouting.Update)]
        public async Task<IActionResult> Edit([FromBody] EditStudentCommand std)
        {
            var response = await Mediator.Send(std);

            return NewResult(response);
        }
        [HttpDelete(Router.StudentRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeleteStudentCommand(id));

            return NewResult(response);
        }
    }
}
