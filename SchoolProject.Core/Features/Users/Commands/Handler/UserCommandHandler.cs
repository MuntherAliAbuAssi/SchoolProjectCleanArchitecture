using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Basies;
using SchoolProject.Core.Features.Users.Commands.Models;
using SchoolProject.Core.SharedResourcing;
using SchoolProject.Data.Models.Identity;

namespace SchoolProject.Core.Features.Users.Commands.Handler
{
    public class UserCommandHandler : ResponseHandler,
                                     IRequestHandler<CreateUserCommand, Response<string>>,
                                     IRequestHandler<EditUserCommand, Response<string>>
    {
        #region Fields
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly UserManager<User> _userManager;
        #endregion 

        #region Constractor
        public UserCommandHandler(UserManager<User> userManager, IMapper mapper, IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _userManager = userManager;
            _mapper = mapper;
        }

        #endregion

        #region Method Handler

        public async Task<Response<string>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user != null) return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.EmailIsExist]);

            var username = await _userManager.FindByNameAsync(request.UserName);

            if (username != null) return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.UserNameIsExist]);

            var identityUser = _mapper.Map<User>(request);

            var creatResault = await _userManager.CreateAsync(identityUser, request.Password);

            if (!creatResault.Succeeded) return BadRequest<string>(creatResault.Errors.FirstOrDefault().Description);

            return Created("");

        }

        public async Task<Response<string>> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {

            var oldUser = await _userManager.FindByIdAsync(request.Id.ToString());

            if (oldUser == null) return NotFound<string>();

            var newUser = _mapper.Map<EditUserCommand, User>(request, oldUser);

            var result = await _userManager.UpdateAsync(newUser);

            if (!result.Succeeded) return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.FailedUpdated]);

            return Success((string)_stringLocalizer[SharedResourcesKeys.Update]);
        }
        #endregion
    }
}
