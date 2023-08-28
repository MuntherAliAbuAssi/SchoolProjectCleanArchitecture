using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Helpers;
using SchoolProject.Data.Models;
using SchoolProject.Infrastructure.Abstract;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Service.Implementations
{
    public class StudentService : IStudentService
    {
        #region Fields
        private readonly IStudentRepository _studentRepository;
        #endregion

        #region Constructors
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        #endregion

        #region Handles Functions

        public async Task<List<Student>> GetListStudentsAsync()
        {
            return await _studentRepository.GetListStudentsAsync();
        }

        public async Task<Student> GetStudentsByIdWithIncludeAsync(int id)
        {
            //var std = await _studentRepository.GetByIdAsync(id);
            var student = await _studentRepository.GetTableNoTracking()
                                             .Include(x => x.Department)
                                             .Where(x => x.StudID == id)
                                             .FirstOrDefaultAsync();
            return student;
        }

        public async Task<string> AddAysnc(Student student)
        {
            // check if the name is Exist Or not 
            var stdIsFound = await _studentRepository.GetTableNoTracking().Where(x => x.NameAr.Equals(student.NameAr) && x.NameEn.Equals(student.NameEn)).FirstOrDefaultAsync();
            if (stdIsFound != null) return "Exist";
            // Add Student 
            await _studentRepository.AddAsync(student);
            return "Success";
        }

        public async Task<bool> IsNameArExist(string nameAr)
        {
            var stdIsFound = _studentRepository.GetTableNoTracking().Where(x => x.NameAr.Equals(nameAr)).FirstOrDefault();
            if (stdIsFound == null) return false;
            return true;

        }
        public async Task<bool> IsNameEnExist(string nameEn)
        {
            var stdIsFound = _studentRepository.GetTableNoTracking().Where(x => x.NameEn.Equals(nameEn)).FirstOrDefault();
            if (stdIsFound == null) return false;
            return true;

        }
        public async Task<bool> IsNameArExistExcludeSelf(string nameAr, int Id)
        {
            var stdIsFound = await _studentRepository.GetTableNoTracking()
                                                    .Where(x => x.NameAr.Equals(nameAr) & !x.StudID.Equals(Id))
                                                    .FirstOrDefaultAsync();
            if (stdIsFound == null) return false;
            return true;
        }
        public async Task<bool> IsNameEnExistExcludeSelf(string nameEn, int Id)
        {
            var stdIsFound = await _studentRepository.GetTableNoTracking()
                                                    .Where(x => x.NameEn.Equals(nameEn) & !x.StudID.Equals(Id))
                                                    .FirstOrDefaultAsync();
            if (stdIsFound == null) return false;
            return true;
        }
        public async Task<string> EditAsync(Student std)
        {
            await _studentRepository.UpdateAsync(std);
            return "Success";
        }

        public async Task<string> DeleteAsync(Student std)
        {
            var trans = _studentRepository.BeginTransaction();
            try
            {
                await _studentRepository.DeleteAsync(std);
                await trans.CommitAsync();
                return "Success";
            }
            catch
            {
                trans.Rollback();
                return "Failed";
            }

        }

        public async Task<Student> GetByIdAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            return student;
        }

        public IQueryable<Student> GetStudentsQueryable()
        {
            return _studentRepository.GetTableNoTracking().Include(x => x.Department).AsQueryable();
        }

        public IQueryable<Student> FilterStudentPaginatedQuerable(StudentsOrderingEnum orderBy, string search)
        {
            var queryable = _studentRepository.GetTableNoTracking().Include(x => x.Department).AsQueryable();
            if (search != null)
            {
                queryable = queryable.Where(x => x.NameAr.Contains(search) || x.Address.Contains(search));

            }
            switch (orderBy)
            {
                case StudentsOrderingEnum.Name:
                    queryable = queryable.OrderBy(x => x.NameAr);
                    break;
                case StudentsOrderingEnum.Address:
                    queryable = queryable.OrderBy(x => x.Address);
                    break;
                case StudentsOrderingEnum.DepartmentName:
                    queryable = queryable.OrderBy(x => x.Department.DNameAr);
                    break;
                default:
                    break;
            }
            return queryable;
        }

        public IQueryable<Student> GetStudentsByDepartmentAsync(int id)
        {
            return _studentRepository.GetTableNoTracking().Where(x => x.DID.Equals(id)).AsQueryable();
        }

        #endregion
    }
}
