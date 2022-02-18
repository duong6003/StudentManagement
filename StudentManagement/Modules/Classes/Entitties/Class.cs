using StudentManagement.Common;
using System;
using System.Collections.Generic;

#nullable disable

namespace StudentManagement.Models
{
    public partial class Class : DomainClass<string>
    {
        public Class()
        {
            Students = new HashSet<Student>();
        }

        public string ClassName { get; set; }
        public int ClassSize { get; set; }
        public string HomeroomTeacherCode { get; set; }

        public virtual Teacher HomeroomTeacherCodeNavigation { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
