using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Data.Models;

namespace SchoolProject.Core.Mapping.Students
{
    public partial class UserProfile
    {
        public void EditStudentMapping()
        {
            CreateMap<EditStudentCommand, Student>()
                    .ForMember(dest => dest.DID, op => op.MapFrom(src => src.DepartmentId))
                    .ForMember(dest => dest.NameAr, opt => opt.MapFrom(src => src.NameAr))
                    .ForMember(dest => dest.NameEn, opt => opt.MapFrom(src => src.NameEn));

        }
    }
}
