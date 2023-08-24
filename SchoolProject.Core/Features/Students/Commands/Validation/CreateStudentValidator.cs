using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.SharedResourcing;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Students.Commands.Validation
{
    public class CreateStudentValidator : AbstractValidator<CreateStudentCommand>
    {
        #region Fields 
        private readonly IStudentService _studentService;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IDepartmentService _departmentService;
        #endregion
        #region Constractor
        public CreateStudentValidator(IDepartmentService departmentService, IStudentService studentService, IStringLocalizer<SharedResources> stringLocalizer)
        {
            _studentService = studentService;
            _stringLocalizer = stringLocalizer;
            _departmentService = departmentService;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }
        #endregion
        #region Action
        public void ApplyValidationRules()
        {
            RuleFor(x => x.NameAr)
                    .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                    .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required])
                    .MaximumLength(100).WithMessage(_stringLocalizer[SharedResourcesKeys.MaximumLength100]);
            RuleFor(x => x.NameEn)
                    .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                    .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required])
                    .MaximumLength(100).WithMessage(_stringLocalizer[SharedResourcesKeys.MaximumLength100]);

            RuleFor(x => x.Address)
                   .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                   .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required])
                   .MaximumLength(100).WithMessage(_stringLocalizer[SharedResourcesKeys.MaximumLength100]);

            RuleFor(x => x.Address)
                          .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                          .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required]);
        }
        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.NameAr)
                .MustAsync(async (model, Key, CancellationToken) => !await _studentService.IsNameArExist(Key))
                .WithMessage(_stringLocalizer[SharedResourcesKeys.IsExist]);

            RuleFor(x => x.NameEn)
               .MustAsync(async (model, Key, CancellationToken) => !await _studentService.IsNameEnExist(Key))
               .WithMessage(_stringLocalizer[SharedResourcesKeys.IsExist]);


            When(x => x.DepartmentId != null, () =>
            {
                RuleFor(x => x.DepartmentId)
                        .MustAsync(async (model, Key, CancellationToken) => await _departmentService.GetDepartmentByIdExist(Key))
                        .WithMessage(_stringLocalizer[SharedResourcesKeys.DepartmentIdIsNotExist]);
            });


        }
        #endregion

    }
}
