using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Models;
using SchoolProject.Infrastructure.Abstract;
using SchoolProject.Infrastructure.Context;
using SchoolProject.Infrastructure.InfrastructureBasies;

namespace SchoolProject.Infrastructure.Repositories
{
    public class SubjectRepository : GenericRepositoryAsync<Subject>, ISubjectRepository
    {
        #region Fields
        private readonly DbSet<Subject> _subject;
        #endregion

        #region Constractor
        public SubjectRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _subject = _dbContext.Set<Subject>();
        }
        #endregion
        #region Handle Function

        #endregion

    }
}
