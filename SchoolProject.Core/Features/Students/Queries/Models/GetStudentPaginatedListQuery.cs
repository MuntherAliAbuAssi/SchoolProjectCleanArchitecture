using MediatR;
using SchoolProject.Core.Features.Students.Responsies;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Helpers;

namespace SchoolProject.Core.Features.Students.Queries.Models
{
    public class GetStudentPaginatedListQuery : IRequest<PaginatedResult<GetStudentPaginatedListResponse>>
    {
        //filters
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public StudentsOrderingEnum OrderBy { get; set; }
        public string? Search { get; set; }
    }
}
