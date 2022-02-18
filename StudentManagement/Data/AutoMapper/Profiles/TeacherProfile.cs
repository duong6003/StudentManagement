using AutoMapper;
using StudentManagement.Models;
using StudentManagement.Modules.Teachers.Requests;

namespace StudentManagement.DataAccess.AutoMapper.Profiles
{
    public class TeacherProfile : Profile
    {
        public TeacherProfile()
        {
            CreateMap<Teacher, TeacherRequest>()
                .ForMember(dest => dest.Classes, opt => opt.Ignore());
            CreateMap<TeacherRequest, Teacher>();
        }
    }
}