using StudentManagement.Modules.ExamResults.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Modules.Subjects.Requests
{
    public class SubjectRequest
    {
        public string SubjectCode { get; set; }
        public string Name { get; set; }
        public int NumberOfCredit { get; set; }
    }
}
