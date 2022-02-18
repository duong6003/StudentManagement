using AutoMapper;
using StudentManagement.Models;
using StudentManagement.Modules.Students.Requests;
using static StudentManagement.DataAccess.AutoMapper.Resolvers.StudentResolver;

namespace StudentManagement.DataAccess.AutoMapper.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<StudentRequest, Student>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom<GetFirstNameResolver>())
                .ForMember(dest => dest.LastName, opt => opt.MapFrom<GetLastNameResolver>())
                .ForMember(dest =>dest.CurriculumVitae, opt => opt.Ignore());
            CreateMap<Student, StudentRequest>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName))
                .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ClassName, opt => opt.MapFrom(src => src.ClassCodeNavigation.ClassName));
            CreateMap<Class, Student>(MemberList.None);
        }
    }
}