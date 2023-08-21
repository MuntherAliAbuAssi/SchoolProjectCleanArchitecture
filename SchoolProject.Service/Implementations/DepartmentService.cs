using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Models;
using SchoolProject.Infrastructure.Abstract;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Service.Implementations
{
    public class DepartmentService : IDepartmentService
    {
        #region Feilds
        private readonly IDepartmentRepository _departmentRepository;
        #endregion

        #region Constractor
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        #endregion

        #region Handle Function
        public async Task<Department> GetDepartmentById(int id)
        {
            return await _departmentRepository.GetTableNoTracking()
                                        .Where(x => x.DID.Equals(id))
                                        .Include(x => x.Instractors)
                                        .Include(x => x.DepartmentSubjects).ThenInclude(x => x.Subject)
                                        .Include(x => x.Instractor)
                                        .FirstOrDefaultAsync();

        }

        #endregion
    }
}
