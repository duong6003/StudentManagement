using StudentManagement.Common;
using System;
using System.Collections.Generic;

#nullable disable

namespace StudentManagement.Models
{
    public partial class Subject : DomainClass<string>
    {
        public string Name { get; set; }
        public int NumberOfCredit { get; set; }
        public virtual ICollection<ExamResult> ExamResults { get; set; }
    }
}
