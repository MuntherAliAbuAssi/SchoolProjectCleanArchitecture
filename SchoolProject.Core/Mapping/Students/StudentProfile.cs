using AutoMapper;


namespace SchoolProject.Core.Mapping.Students
{
    public partial class UserProfile : Profile
    {
        public UserProfile()
        {
            GetStudentListMapping();
            GetSingleStudentMapping();
            CreateStudentMapping();
            EditStudentMapping();
            GetStudentListPaginatedMapping();
        }
    }
}
