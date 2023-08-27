using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Users.Commands.Models;
using SchoolProject.Core.SharedResourcing;

namespace SchoolProject.Core.Features.Users.Commands.Validation
{
    public class ChangeUserPasswordValidator : AbstractValidator<ChangeUserPasswordCommand>
    {

        #region Fields
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion

        #region Constractor
        public ChangeUserPasswordValidator(IStringLocalizer<SharedResources> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }


        #endregion

        #region Actions 
        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.Id)
                         .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                         .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required]);

            RuleFor(x => x.CurrentPassword)
                   .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                   .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required]);
            RuleFor(x => x.NewPassword)
                    .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                    .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required]);

            RuleFor(x => x.ConfirmPassword)
                          .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                          .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required])
                          .Equal(x => x.NewPassword).WithMessage(_stringLocalizer[SharedResourcesKeys.PasswardNoEqualsConfirmPass]);

        }

        public void ApplyValidationRules()
        {
            //
        }
        #endregion
    }
}
