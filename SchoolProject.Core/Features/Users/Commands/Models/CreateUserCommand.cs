﻿using MediatR;
using SchoolProject.Core.Basies;

namespace SchoolProject.Core.Features.Users.Commands.Models
{
    public class CreateUserCommand : IRequest<Response<string>>
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }

    }
}
