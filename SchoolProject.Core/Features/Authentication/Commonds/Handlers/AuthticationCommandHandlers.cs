using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Basies;
using SchoolProject.Core.Features.Authentication.Commonds.Models;
using SchoolProject.Core.SharedResourcing;
using SchoolProject.Data.Models.Identity;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Authentication.Commonds.Handlers
{
    public class AuthticationCommandHandlers : ResponseHandler, IRequestHandler<LoginCommand, Response<string>>
    {
        #region Fields
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IAuthenticationService _authenticationService;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        #endregion
        #region Constractor
        public AuthticationCommandHandlers(IAuthenticationService authenticationService,
                                     SignInManager<User> signInManager,
                                     UserManager<User> userManager,
                                     IMapper mapper,
                                     IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _authenticationService = authenticationService;
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;

        }
        #endregion

        #region handle function

        public async Task<Response<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user == null) return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.UserNameIsNotExist]);

            var loginResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (!loginResult.Succeeded) return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.PasswordOrUserNameNotCorrect]);

            var tokens = await _authenticationService.GetGWTToken(user);

            return Success(tokens);
        }

        #endregion
    }
}
