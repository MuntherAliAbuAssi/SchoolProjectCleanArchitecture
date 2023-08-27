using SchoolProject.Core.Features.Users.Commands.Models;
using SchoolProject.Data.Models.Identity;

namespace SchoolProject.Core.Mapping.Users
{
    public partial class UserProfile
    {
        public void EditUserMapping()
        {
            CreateMap<EditUserCommand, User>();

        }
    }
}
