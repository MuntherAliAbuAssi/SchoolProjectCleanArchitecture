using SchoolProject.Data.Helpers;
using SchoolProject.Data.Models;

namespace SchoolProject.Service.Abstracts
{
    public interface IStudentService
    {
        public Task<List<Student>> GetListStudentsAsync();
        public IQueryable<Student> GetStudentsQueryable();
        public Task<Student> GetStudentsByIdWithIncludeAsync(int id);
        public Task<Student> GetByIdAsync(int id);
        public Task<string> AddAysnc(Student std);
        public Task<bool> IsNameArExist(string nameAr);
        public Task<bool> IsNameEnExist(string nameEn);
        public Task<bool> IsNameArExistExcludeSelf(string nameAr, int Id);
        public Task<bool> IsNameEnExistExcludeSelf(string nameEn, int Id);
        public Task<string> EditAsync(Student std);
        public Task<string> DeleteAsync(Student std);
        public IQueryable<Student> GetStudentsByDepartmentAsync(int id);
        public IQueryable<Student> FilterStudentPaginatedQuerable(StudentsOrderingEnum orderBy, string search);


    }
}
