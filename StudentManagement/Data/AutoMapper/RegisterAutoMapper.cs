using AutoMapper;
using StudentManagement.DataAccess.AutoMapper.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.DataAccess.AutoMapper
{ 
    public class RegisterAutoMapper
    {
        public static MapperConfiguration RegisterConfigure()
        {
            return new MapperConfiguration(cfg =>
                {
                    cfg.AddMaps("StudentManagement");
                    cfg.SourceMemberNamingConvention = new PascalCaseNamingConvention();
                    cfg.DestinationMemberNamingConvention = new PascalCaseNamingConvention();
                }
            );
        }
    }
}
