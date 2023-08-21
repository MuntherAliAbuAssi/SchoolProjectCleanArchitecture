using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Models;
using SchoolProject.Infrastructure.Abstract;
using SchoolProject.Infrastructure.Context;
using SchoolProject.Infrastructure.InfrastructureBasies;

namespace SchoolProject.Infrastructure.Repositories
{
    public class StudentRepository : GenericRepositoryAsync<Student>, IStudentRepository
    {
        #region Fields
        private readonly DbSet<Student> _student;
        #endregion

        #region Constructors
        public StudentRepository(ApplicationDbContext _dbContext) : base(_dbContext)
        {
            _student = _dbContext.Set<Student>();
        }
        #endregion

        #region Handles Functions
        public async Task<List<Student>> GetListStudentsAsync()
        {
            return await _student.Include(x => x.Department).ToListAsync();
        }


        #endregion

    }
}
