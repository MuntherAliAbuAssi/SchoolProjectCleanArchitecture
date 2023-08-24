using SchoolProject.Data.Models;

namespace SchoolProject.Service.Abstracts
{
    public interface IDepartmentService
    {
        public Task<Department> GetDepartmentById(int id);
        public Task<bool> GetDepartmentByIdExist(int Id);
    }
}
