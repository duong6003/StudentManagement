using StudentManagement.Common;
using System;
using System.Collections.Generic;

#nullable disable

namespace StudentManagement.Models
{
    public partial class ExamResult : DomainClass<int>
    {
        public string SubjectCode { get; set; }
        public string StudentId { get; set; }
        public int Mark { get; set; }
        public bool IsPass { get; set; }

        public virtual Student Student { get; set; }
        public virtual Subject SubjectCodeNavigation { get; set; }
    }
}
