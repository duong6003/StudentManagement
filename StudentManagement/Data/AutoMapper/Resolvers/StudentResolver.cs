using AutoMapper;
using StudentManagement.Models;
using StudentManagement.Modules.Students;
using StudentManagement.Modules.Students.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.DataAccess.AutoMapper.Resolvers
{
    public class StudentResolver
    {
        public class GetFirstNameResolver : IValueResolver<StudentRequest, Student, string>
        {
            public string Resolve(StudentRequest source, Student destination, string destMember, ResolutionContext context)
            {
                return source.FullName.Trim().Split(" ").FirstOrDefault();
            }
        }
        public class GetLastNameResolver : IValueResolver<StudentRequest, Student, string>
        {
            public string Resolve(StudentRequest source, Student destination, string destMember, ResolutionContext context)
            {
                IEnumerable<string> lastNames = source.FullName.Trim().Split(" ").Skip(1);
                StringBuilder sb = new StringBuilder() ;
                foreach(string name in lastNames)
                {
                    sb.Append(name + " ");
                }
                return sb.ToString().Trim();
            }
        }
        public class GetFullNameResolver : IValueResolver<Student, StudentRequest, string>
        {
            public string Resolve(Student source, StudentRequest destination, string destMember, ResolutionContext context)
            {
                return source.FirstName.Trim() + " " + source.LastName.Trim();
            }
        }
    }   
}
