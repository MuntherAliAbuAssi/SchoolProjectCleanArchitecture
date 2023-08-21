using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Models;
using SchoolProject.Infrastructure.Abstract;
using SchoolProject.Infrastructure.Context;
using SchoolProject.Infrastructure.InfrastructureBasies;

namespace SchoolProject.Infrastructure.Repositories
{
    public class InstractorRepository : GenericRepositoryAsync<Instractor>, IInstractorRepository
    {
        #region Fields
        private readonly DbSet<Instractor> _instractor;
        #endregion

        #region Constractor
        public InstractorRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _instractor = _dbContext.Set<Instractor>();
        }
        #endregion

        #region Handles Functions

        #endregion

    }
}
