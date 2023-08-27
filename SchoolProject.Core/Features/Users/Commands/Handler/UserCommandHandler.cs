using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Basies;
using SchoolProject.Core.Features.Users.Commands.Models;
using SchoolProject.Core.SharedResourcing;
using SchoolProject.Data.Models.Identity;

namespace SchoolProject.Core.Features.Users.Commands.Handler
{
    public class UserCommandHandler : ResponseHandler,
                                     IRequestHandler<CreateUserCommand, Response<string>>,
                                     IRequestHandler<EditUserCommand, Response<string>>,
                                     IRequestHandler<DeleteUserCommand, Response<string>>,
                                     IRequestHandler<ChangeUserPasswordCommand, Response<string>>

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

            var username = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == newUser.UserName && x.Id == newUser.Id);

            if (username != null) return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.UserNameIsExist]);

            var result = await _userManager.UpdateAsync(newUser);

            if (!result.Succeeded) return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.FailedUpdated]);

            return Success((string)_stringLocalizer[SharedResourcesKeys.Update]);
        }

        public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id.ToString());

            if (user == null) return NotFound<string>(_stringLocalizer[SharedResourcesKeys.NotFound]);

            var result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded) return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.DeletedFailed]);

            return Deleted<string>(_stringLocalizer[SharedResourcesKeys.Deleted] + $" {user.Id}");
        }

        public async Task<Response<string>> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id.ToString());

            if (user == null) return NotFound<string>();

            var result = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);

            if (!result.Succeeded) return BadRequest<string>(result.Errors.FirstOrDefault().Description);

            return Success((string)_stringLocalizer[SharedResourcesKeys.ChangePasswordSuccess]);

        }

        #endregion
    }
}
