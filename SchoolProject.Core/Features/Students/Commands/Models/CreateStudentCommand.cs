﻿
using MediatR;
using SchoolProject.Core.Basies;


namespace SchoolProject.Core.Features.Students.Commands.Models
{
    public class CreateStudentCommand : IRequest<Response<string>>
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string Address { get; set; }
        public string? Phone { get; set; }
        public int DepartmentId { get; set; }
    }
}
