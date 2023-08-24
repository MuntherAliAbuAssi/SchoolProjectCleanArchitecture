using SchoolProject.Core.Features.Students.Responsies;
using SchoolProject.Data.Models;

namespace SchoolProject.Core.Mapping.Students
{
    public partial class StudentProfile
    {
        public void GetStudentListPaginatedMapping()
        {
            CreateMap<Student, GetStudentPaginatedListResponse>()
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Localize(src.Department.DNameAr, src.Department.DNameEn)))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.NameAr, src.NameEn)))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.StudID, opt => opt.MapFrom(src => src.StudID));

        }
    }
}
