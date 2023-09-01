using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Models.Identity;
using SchoolProject.Infrastructure.Abstract;
using SchoolProject.Infrastructure.Context;
using SchoolProject.Infrastructure.InfrastructureBasies;

namespace SchoolProject.Infrastructure.Repositories
{
    public class RefreshTokenRepositroy : GenericRepositoryAsync<UserRefreshToken>, IRefreshTokenRepository
    {
        #region Feilds
        private DbSet<UserRefreshToken> _userRefreshTokens;
        #endregion
        #region Constractor
        public RefreshTokenRepositroy(ApplicationDbContext dbContext) : base(dbContext)
        {
            _userRefreshTokens = dbContext.Set<UserRefreshToken>();
        }
        #endregion
        #region Handle Function
        #endregion

    }
}
