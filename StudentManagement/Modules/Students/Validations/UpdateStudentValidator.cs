using FluentValidation;
using StudentManagement.Modules.Students.Requests;
using StudentManagement.Modules.Students.Services.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StudentManagement.Modules.Students.Validations
{
    public class UpdateStudentValidator : AbstractValidator<UpdateStudentRequest>
    {
        private readonly StudentService _studentService;
        public UpdateStudentValidator(StudentService studentService)
        {
            _studentService = studentService;
            RuleFor(x => x.StudentId)
                .NotEmpty().WithMessage("Không để trống")
                .MaximumLength(10).WithMessage("Mã lớp không quá mười kí tự")
                .Matches("[a-z0-9]").WithMessage("Không chứa kí tự đặc biệt")
                .Must((student, id) => _studentService.IsExistId(id)).WithMessage("{PropertyValue} không tồn tại");
            RuleFor(x => x.CurriculumVitae)
                .Must((student, file, context) => _studentService.IsValidFile(file)).WithMessage("Vui lòng nhập file pdf");
            RuleFor(x => x.CurriculumVitae.FileName)
                .MaximumLength(30).WithMessage("Tên File không quá 30 kí tự");
        }
    }
}
