using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Authentication.Commonds.Models;
using SchoolProject.Core.SharedResourcing;

namespace SchoolProject.Core.Features.Authentication.Commonds.Validation
{
    public class LoginValidator : AbstractValidator<LoginCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion

        #region Constractor
        public LoginValidator(IStringLocalizer<SharedResources> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }


        #endregion

        #region Actions 
        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.UserName)
                    .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                    .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required]);
            RuleFor(x => x.Password)
                          .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                          .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required]);


        }

        public void ApplyValidationRules()
        {
            //
        }
        #endregion
    }
}
