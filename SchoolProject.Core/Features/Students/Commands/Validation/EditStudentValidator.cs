using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.SharedResourcing;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Students.Commands.Validation
{
    public class EditStudentValidator : AbstractValidator<EditStudentCommand>
    {
        #region Fields  
        private readonly IStudentService _studentService;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        #endregion
        #region Constractor
        public EditStudentValidator(IStudentService studentService, IStringLocalizer<SharedResources> stringLocalizer)
        {
            _studentService = studentService;
            _stringLocalizer = stringLocalizer;
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
        }
        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.NameAr)
                .MustAsync(async (model, key, CancellationToken) => !await _studentService.IsNameArExistExcludeSelf(key, model.StudID))
                .WithMessage(_stringLocalizer[SharedResourcesKeys.Required]);
            RuleFor(x => x.NameEn)
               .MustAsync(async (model, key, CancellationToken) => !await _studentService.IsNameEnExistExcludeSelf(key, model.StudID))
               .WithMessage(_stringLocalizer[SharedResourcesKeys.Required]);

        }
        #endregion 
    }
}
