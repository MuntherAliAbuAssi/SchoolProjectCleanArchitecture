using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Users.Commands.Models;
using SchoolProject.Core.SharedResourcing;

namespace SchoolProject.Core.Features.Users.Commands.Validation
{
    public class UpdateUserValidator : AbstractValidator<EditUserCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion

        #region Constractor
        public UpdateUserValidator(IStringLocalizer<SharedResources> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }


        #endregion

        #region Actions 
        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.FullName)
                   .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                   .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required])
                   .MaximumLength(100).WithMessage(_stringLocalizer[SharedResourcesKeys.MaximumLength100]);
            RuleFor(x => x.UserName)
                    .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                    .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required])
                    .MaximumLength(100).WithMessage(_stringLocalizer[SharedResourcesKeys.MaximumLength100]);
            RuleFor(x => x.Email)
                          .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                          .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required])
                          .EmailAddress().WithMessage(_stringLocalizer[SharedResourcesKeys.InvalidEmail]);


        }

        public void ApplyValidationRules()
        {
            //
        }
        #endregion


    }
}
