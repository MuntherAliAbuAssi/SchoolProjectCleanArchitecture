using SchoolProject.Data.Models;
using SchoolProject.Infrastructure.InfrastructureBasies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrastructure.Abstract
{
    public interface IStudentRepository :IGenericRepositoryAsync<Student>
    {
        public Task<List<Student>> GetListStudentsAsync();

    }
}
