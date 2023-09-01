using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Basies;
using SchoolProject.Core.Features.Authentication.Queries.Models;
using SchoolProject.Core.SharedResourcing;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Authentication.Queries.Handlers
{
    public class AuthticationQueryHandlers : ResponseHandler,
                                                              IRequestHandler<AuthorizeUserQuery, Response<string>>
    {
        #region Fields
        private readonly IAuthenticationService _authenticationService;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion
        #region Constractor
        public AuthticationQueryHandlers(
                                           IAuthenticationService authenticationService,
                                           IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _authenticationService = authenticationService;
            _stringLocalizer = stringLocalizer;

        }


        #endregion

        #region handle function

        public async Task<Response<string>> Handle(AuthorizeUserQuery request, CancellationToken cancellationToken)
        {
            var result = await _authenticationService.VaildateToken(request.AccessToken);

            if (result == "NotExpired")
                return Success(result);
            return Unauthorized<string>(_stringLocalizer[SharedResourcesKeys.TokenIsExpired]);

        }

        #endregion
    }
}
