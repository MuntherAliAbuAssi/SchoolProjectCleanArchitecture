using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Basies;
using SchoolProject.Core.Features.Departments.Queries.Models;
using SchoolProject.Core.Features.Departments.Responsies;
using SchoolProject.Core.SharedResourcing;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Models;
using SchoolProject.Service.Abstracts;
using System.Linq.Expressions;

namespace SchoolProject.Core.Features.Departments.Queries.Handler
{
    public class DepartmentQueryHandler : ResponseHandler,
        IRequestHandler<GetDepartmentByIdQuery, Response<GetDepartmentByIdResponse>>
    {

        #region Feilds 
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IDepartmentService _departmentService;
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        #endregion
        #region Constractors
        public DepartmentQueryHandler(IStudentService studentService, IMapper mapper, IStringLocalizer<SharedResources> stringLocalizer, IDepartmentService departmentService) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _departmentService = departmentService;
            _studentService = studentService;
            _mapper = mapper;
        }


        #endregion

        #region Handle Function 
        public async Task<Response<GetDepartmentByIdResponse>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {

            var response = await _departmentService.GetDepartmentById(request.Id);
            if (response == null) return NotFound<GetDepartmentByIdResponse>(_stringLocalizer[SharedResourcesKeys.NotFound]);

            var map = _mapper.Map<GetDepartmentByIdResponse>(response);

            Expression<Func<Student, StudentResponse>> expression = e => new StudentResponse(e.StudID, e.Localize(e.NameAr, e.NameEn));
            var studentQuerable = _studentService.GetStudentsByDepartmentAsync(request.Id);
            var paginatedStudent = await studentQuerable.Select(expression).ToPaginatedListAsync(request.StudentPageNumber, request.StudentPageSize);
            map.StudentList = paginatedStudent;
            return Success(map);
        }


        #endregion

    }
}
