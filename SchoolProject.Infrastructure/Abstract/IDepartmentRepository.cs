using SchoolProject.Data.Models;
using SchoolProject.Infrastructure.InfrastructureBasies;

namespace SchoolProject.Infrastructure.Abstract
{
    public interface IDepartmentRepository : IGenericRepositoryAsync<Department>
    {
    }
}
