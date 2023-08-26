using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Data.Models;

namespace SchoolProject.Core.Mapping.Students
{
    public partial class UserProfile
    {
        public void CreateStudentMapping()
        {
            CreateMap<CreateStudentCommand, Student>()
                            .ForMember(dest => dest.DID, opt => opt.MapFrom(src => src.DepartmentId))
                            .ForMember(dest => dest.NameAr, opt => opt.MapFrom(src => src.NameAr))
                            .ForMember(dest => dest.NameEn, opt => opt.MapFrom(src => src.NameEn));

        }
    }
}
