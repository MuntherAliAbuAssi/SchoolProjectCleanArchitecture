using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Basies;
using SchoolProject.Core.Features.Authentication.Commonds.Models;
using SchoolProject.Core.SharedResourcing;
using SchoolProject.Data.Helpers;
using SchoolProject.Data.Models.Identity;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Authentication.Commonds.Handlers
{
    public class AuthticationCommandHandlers : ResponseHandler,
                                                              IRequestHandler<LoginCommand, Response<JwtAuthResult>>,
                                                              IRequestHandler<RefreshTokenCommand, Response<JwtAuthResult>>
    {
        #region Fields
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IAuthenticationService _authenticationService;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion
        #region Constractor
        public AuthticationCommandHandlers(
                                           IAuthenticationService authenticationService,
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

        public async Task<Response<JwtAuthResult>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user == null) return BadRequest<JwtAuthResult>(_stringLocalizer[SharedResourcesKeys.UserNameIsNotExist]);

            var loginResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (!loginResult.Succeeded) return BadRequest<JwtAuthResult>(_stringLocalizer[SharedResourcesKeys.PasswordOrUserNameNotCorrect]);

            var tokens = await _authenticationService.GetGWTTokenAsync(user);

            return Success(tokens);
        }

        public async Task<Response<JwtAuthResult>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var jwtToken = _authenticationService.ReadJwtToken(request.AccessToken);
            var userIdAndExpiredAt = await _authenticationService.VaildateDetails(jwtToken, request.AccessToken, request.RefreshToken);
            switch (userIdAndExpiredAt)
            {
                case ("AlgorithmIsWrong", null):
                    return Unauthorized<JwtAuthResult>(_stringLocalizer[SharedResourcesKeys.AlgorithmIsWrong]);
                    break;
                case ("TokenIsNotExpired", null):
                    return Unauthorized<JwtAuthResult>(_stringLocalizer[SharedResourcesKeys.TokenIsNotExpired]);
                    break;
                case ("RefreshTokenIsNotFound", null):
                    return Unauthorized<JwtAuthResult>(_stringLocalizer[SharedResourcesKeys.RefreshTokenIsNotFound]);
                    break;
                case ("RefreshTokenIsExpired", null):
                    return Unauthorized<JwtAuthResult>(_stringLocalizer[SharedResourcesKeys.RefreshTokenIsExpired]);
                    break;
            }
            var (userId, expireAt) = userIdAndExpiredAt;
            var user = await _userManager.FindByIdAsync((userId));

            if (user == null)
            {
                return NotFound<JwtAuthResult>();
            }
            var result = await _authenticationService.GetRefreshTokenAsync(user, jwtToken, request.RefreshToken, expireAt);
            return Success(result);
        }

        #endregion
    }
}
