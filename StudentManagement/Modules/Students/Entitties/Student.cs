using StudentManagement.Common;
using System;
using System.Collections.Generic;

#nullable disable

namespace StudentManagement.Models
{
    public partial class Student : DomainClass<string>
    {
        public Student()
        {
            ExamResults = new HashSet<ExamResult>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDay { get; set; }
        public bool Gender { get; set; }
        public string Address { get; set; }
        public string ClassCode { get; set; }
        public string Email { get; set; }
        public string CurriculumVitae { get; set; }

        public virtual Class ClassCodeNavigation { get; set; }
        public virtual ICollection<ExamResult> ExamResults { get; set; }
    }
}
