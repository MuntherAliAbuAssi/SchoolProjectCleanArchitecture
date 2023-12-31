﻿using MediatR;
using SchoolProject.Core.Basies;
using SchoolProject.Data.Helpers;

namespace SchoolProject.Core.Features.Authentication.Commonds.Models
{
    public class LoginCommand : IRequest<Response<JwtAuthResult>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
