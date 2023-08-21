using SchoolProject.Core.Features.Departments.Responsies;
using SchoolProject.Data.Models;

namespace SchoolProject.Core.Mapping.Departments
{
    public partial class DepartmentProfile
    {
        public void GetDepartmentByIdMapping()
        {
            CreateMap<Department, GetDepartmentByIdResponse>()
                     .ForMember(dest => dest.Name, op => op.MapFrom(src => src.Localize(src.DNameAr, src.DNameEn)))
                     .ForMember(dest => dest.ManagerName, op => op.MapFrom(dest => dest.Instractor.Localize(dest.Instractor.ENameAr, dest.Instractor.ENameEn)))
                     .ForMember(dest => dest.SubjectList, op => op.MapFrom(src => src.DepartmentSubjects))
                     /*   .ForMember(dest => dest.StudentList, op => op.MapFrom(src => src.Students))*/
                     .ForMember(dest => dest.InstractorList, op => op.MapFrom(src => src.Instractors));

            CreateMap<DepartmetSubject, SubjectResponse>()
                .ForMember(dest => dest.Id, op => op.MapFrom(src => src.DID))
                .ForMember(dest => dest.Name, op => op.MapFrom(src => src.Localize(src.Subject.SubjectNameAr, src.Subject.SubjectNameEn)));


            /* CreateMap<Student, StudentResponse>()
             .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.StudID))
             .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.NameAr, src.NameEn)));*/

            CreateMap<Instractor, InstractorResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.InsId))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.ENameAr, src.ENameEn)));

        }
    }
}
