using AutoMapper;
using StudentManagement.Models;
using StudentManagement.Modules.ExamResults.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Data.AutoMapper.Profiles
{
    public class ExamResultProfile: Profile
    { 
        public ExamResultProfile() 
        {
            CreateMap<ExamResult, GetExamResultRequet>()
                .ForMember(dest => dest.StudentName, opt => opt.MapFrom(src => src.Student.FirstName + " " + src.Student.LastName))
                .ForMember(dest => dest.SubjectName, opt => opt.MapFrom(src => src.SubjectCodeNavigation.Name));
                
            CreateMap<Student, ExamResult>(MemberList.None);
            CreateMap<Subject, ExamResult>(MemberList.None);
        }
    }
}
