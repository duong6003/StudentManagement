using Microsoft.AspNetCore.Http;
using StudentManagement.Modules.Classes.Requests;
using StudentManagement.Modules.ExamResults.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Modules.Students.Requests
{
    public class StudentRequest
    {
        public string StudentId { get; set; }
        public string FullName { get; set; }
        public DateTime? BirthDay { get; set; }
        public bool Gender { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ClassCode { get; set; }
        public string ClassName { get; set; }
    }
}
