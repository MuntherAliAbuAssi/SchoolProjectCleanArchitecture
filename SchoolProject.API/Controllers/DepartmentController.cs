using Microsoft.AspNetCore.Mvc;
using SchoolProject.API.Base;
using SchoolProject.Core.Features.Departments.Queries.Models;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.API.Controllers
{
    public class DepartmentController : AppControllerBase
    {

        [HttpGet(Router.DepartmentRouting.GetDepartmentByID)]
        public async Task<IActionResult> GetDepartmentByIdAsync([FromQuery] GetDepartmentByIdQuery query)
        {
            var response = await Mediator.Send(query);

            return NewResult(response);
        }
    }
}
