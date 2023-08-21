using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Models;
using SchoolProject.Infrastructure.Abstract;
using SchoolProject.Infrastructure.Context;
using SchoolProject.Infrastructure.InfrastructureBasies;

namespace SchoolProject.Infrastructure.Repositories
{
    public class DepartmentRepository : GenericRepositoryAsync<Department>, IDepartmentRepository
    {
        #region Fields
        private readonly DbSet<Department> _department;
        #endregion

        #region Constractor
        public DepartmentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _department = _dbContext.Set<Department>();
        }
        #endregion
        #region Handle Function

        #endregion

    }
}
