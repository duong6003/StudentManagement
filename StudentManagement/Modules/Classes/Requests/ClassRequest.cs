using StudentManagement.Modules.Students.Requests;
using StudentManagement.Modules.Teachers.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Modules.Classes.Requests
{
    public class ClassRequest
    {
        public string ClassCode { get; set; }
        public string ClassName { get; set; }
        public int ClassSize { get; set; }
        public string HomeroomTeacherCode { get; set; }

        public TeacherRequest HomeroomTeacherCodeNavigation { get; set; }
        public ICollection<StudentRequest> Students { get; set; }
    }
}
