using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Modules.Students.Requests
{
    public class UpdateStudentRequest
    {
        public string StudentId { get; set; }
        public IFormFile CurriculumVitae { get; set; }
    }
}
