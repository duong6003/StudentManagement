using StudentManagement.Modules.Students.Requests;
using StudentManagement.Modules.Subjects.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Modules.ExamResults.Requests
{
    public class GetExamResultRequet
    {
        public string SubjectName { get; set; }
        public string StudentName { get; set; }
        public int Mark { get; set; }
        public bool IsPass { get; set; }
    }
}
