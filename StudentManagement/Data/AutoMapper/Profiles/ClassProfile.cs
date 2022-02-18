using AutoMapper;
using StudentManagement.Models;
using StudentManagement.Modules.Classes.Requests;

namespace StudentManagement.DataAccess.AutoMapper.Profiles
{
    public class ClassProfile : Profile
    {
        public ClassProfile()
        {
            CreateMap<Class, ClassRequest>();
        }
    }
}