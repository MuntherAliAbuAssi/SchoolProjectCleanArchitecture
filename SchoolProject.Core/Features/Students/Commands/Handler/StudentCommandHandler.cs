using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Basies;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.SharedResourcing;
using SchoolProject.Data.Models;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Students.Commands.Handler
{
    public class StudentCommandHandler : ResponseHandler, IRequestHandler<CreateStudentCommand, Response<string>>
                                                        , IRequestHandler<EditStudentCommand, Response<string>>
                                                        , IRequestHandler<DeleteStudentCommand, Response<string>>

    {
        #region Fields
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        #endregion
        #region Constractor
        public StudentCommandHandler(IStudentService studentService,
                                     IMapper mapper,
                                     IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _studentService = studentService;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;

        }
        #endregion

        #region handle function
        public async Task<Response<string>> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var studentmapping = _mapper.Map<Student>(request);

            var result = await _studentService.AddAysnc(studentmapping);

            if (result == "Success") return Created<string>(_stringLocalizer[SharedResourcesKeys.Created]);

            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            var std = await _studentService.GetByIdAsync(request.StudID);

            if (std == null) return NotFound<string>(_stringLocalizer[SharedResourcesKeys.NotFound]);

            var studentmapping = _mapper.Map(request, std);

            var result = await _studentService.EditAsync(studentmapping);

            if (result == "Success") return Success(_stringLocalizer[SharedResourcesKeys.Update] + $" {studentmapping.StudID}");

            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var std = await _studentService.GetByIdAsync(request.Id);

            if (std == null) return NotFound<string>(_stringLocalizer[SharedResourcesKeys.NotFound]);

            var result = await _studentService.DeleteAsync(std);
            if (result == "Success") return Deleted<string>(_stringLocalizer[SharedResourcesKeys.Deleted] + $" {std.StudID}");

            else return BadRequest<string>();

        }
        #endregion
    }
}
