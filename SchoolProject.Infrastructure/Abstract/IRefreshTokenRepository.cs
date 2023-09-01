using SchoolProject.Data.Models.Identity;
using SchoolProject.Infrastructure.InfrastructureBasies;

namespace SchoolProject.Infrastructure.Abstract
{
    public interface IRefreshTokenRepository : IGenericRepositoryAsync<UserRefreshToken>
    {

    }
}
