﻿using SchoolProject.Core.Features.Students.Responsies;
using SchoolProject.Data.Models;

namespace SchoolProject.Core.Mapping.Students
{
    public partial class UserProfile
    {
        public void GetSingleStudentMapping()
        {
            CreateMap<Student, GetSingleStudentResponse>()
                                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Localize(src.Department.DNameAr, src.Department.DNameEn)))
                                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.NameAr, src.NameEn)));

        }
    }
}
