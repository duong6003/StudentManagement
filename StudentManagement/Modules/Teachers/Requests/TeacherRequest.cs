using StudentManagement.Modules.Classes.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Modules.Teachers.Requests
{
    public class TeacherRequest
    {
        public string Id { get; set; }
        public string TeacherCode { get; set; }
        public string FullName { get; set; }
        public DateTime? BirthDay { get; set; }
        public string Degree { get; set; }
        public float Coefficient { get; set; }
        public decimal Salary { get; set; }
        public decimal SalaryOriginal { get; set; }


        public ICollection<ClassRequest> Classes { get; set; }
    }
}
