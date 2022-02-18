using StudentManagement.Common;
using System;
using System.Collections.Generic;

#nullable disable

namespace StudentManagement.Models
{
    public partial class Teacher : DomainClass<string>
    {
        public Teacher()
        {
            Classes = new HashSet<Class>();
        }

        public string FullName { get; set; }
        public DateTime? BirthDay { get; set; }
        public string Degree { get; set; }
        public float Coefficient { get; set; }
        public decimal Salary { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
    }
}
