using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Basies;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Core.Features.Students.Responsies;
using SchoolProject.Core.SharedResourcing;
using SchoolProject.Core.Wrappers;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Students.Queries.Handlers
{
    public class StudentHandler : ResponseHandler, IRequestHandler<GetStudentListQuery, Response<List<GetStudentListResponse>>>
                                                 , IRequestHandler<GetStudentByIdQuery, Response<GetSingleStudentResponse>>
                                                 , IRequestHandler<GetStudentPaginatedListQuery, PaginatedResult<GetStudentPaginatedListResponse>>

    {
        #region Fields
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion
        #region Constractor
        public StudentHandler(IStudentService studentService,
                             IMapper mapper,
                             IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _studentService = studentService;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;

        }
        #endregion

        #region handle function
        public async Task<Response<List<GetStudentListResponse>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var studentList = await _studentService.GetListStudentsAsync();
            var studentListMapper = _mapper.Map<List<GetStudentListResponse>>(studentList);
            var result = Success(studentListMapper);
            result.Meta = new
            {
                Count = studentListMapper.Count(),

            };
            return result;
        }

        public async Task<Response<GetSingleStudentResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentsByIdWithIncludeAsync(request.Id);
            if (student == null) return NotFound<GetSingleStudentResponse>(_stringLocalizer[SharedResourcesKeys.NotFound]);
            var studentMapper = _mapper.Map<GetSingleStudentResponse>(student);
            return Success(studentMapper);
        }

        public async Task<PaginatedResult<GetStudentPaginatedListResponse>> Handle(GetStudentPaginatedListQuery request, CancellationToken cancellationToken)
        {
            // way 1
            // Expression<Func<Student, GetStudentPaginatedListResponse>> expression = e => new GetStudentPaginatedListResponse(e.StudID, e.Localize(e.NameAr, e.NameEn), e.Address, e.Localize(e.Department.DNameAr, e.Department.DNameEn));
            // var paginatedList = await filterQuery.Select(expression)).ToPaginatedListAsync(request.PageNumber, request.PageSize);

            // way 2 
            // var paginatedList = await filterQuery.Select(e => new GetStudentPaginatedListResponse(e.StudID, e.Localize(e.NameAr, e.NameEn), e.Address, e.Localize(e.Department.DNameAr, e.Department.DNameEn))).ToPaginatedListAsync(request.PageNumber, request.PageSize);

            // way 3
            // var paginatedList = await _mapper.ProjectTo<GetStudentPaginatedListResponse>(filterQuery, null).ToPaginatedListAsync(request.PageNumber, request.PageSize);


            var filterQuery = _studentService.FilterStudentPaginatedQuerable(request.OrderBy, request.Search);
            var paginatedList = await _mapper.ProjectTo<GetStudentPaginatedListResponse>(filterQuery, null).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            paginatedList.Meta = new
            {
                Count = paginatedList.Data.Count(),
            };
            return paginatedList;
        }
        #endregion
    }
}
