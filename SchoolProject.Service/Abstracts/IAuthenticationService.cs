using SchoolProject.Data.Models.Identity;

namespace SchoolProject.Service.Abstracts
{
    public interface IAuthenticationService
    {
        public Task<string> GetGWTToken(User user);
    }
}
