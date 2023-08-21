using MediatR;
using SchoolProject.Core.Basies;
using SchoolProject.Core.Features.Students.Responsies;
using SchoolProject.Data.Models;

namespace SchoolProject.Core.Features.Students.Queries.Models
{
    public class GetStudentListQuery : IRequest<Response<List<GetStudentListResponse>>>
    {
    }
}
