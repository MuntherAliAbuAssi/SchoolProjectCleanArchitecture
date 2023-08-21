using SchoolProject.Core.Wrappers;

namespace SchoolProject.Core.Features.Departments.Responsies
{
    public class GetDepartmentByIdResponse
    {
        public int DID { get; set; }
        public string Name { get; set; }
        public string ManagerName { get; set; }
        public PaginatedResult<StudentResponse>? StudentList { get; set; }
        public List<SubjectResponse>? SubjectList { get; set; }
        public List<InstractorResponse>? InstractorList { get; set; }

    }
    public class StudentResponse
    {
        public StudentResponse(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class SubjectResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class InstractorResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
