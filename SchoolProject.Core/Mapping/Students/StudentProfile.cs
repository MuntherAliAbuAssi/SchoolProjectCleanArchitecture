using AutoMapper;


namespace SchoolProject.Core.Mapping.Students
{
    public partial class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            GetStudentListMapping();
            GetSingleStudentMapping();
            CreateStudentMapping();
            EditStudentMapping();
        }
    }
}
