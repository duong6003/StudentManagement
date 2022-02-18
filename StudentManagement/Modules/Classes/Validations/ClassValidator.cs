
using FluentValidation;
using StudentManagement.Modules.Classes.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Modules.Classes.Validations
{
    public class ClassValidator : AbstractValidator<ClassRequest>
    {
        public ClassValidator()
        {
            RuleFor(x => x.ClassCode)
                .NotEmpty().WithMessage("{PropertyName} không được để trống")
                .Length(3, 20).WithMessage("Số kí tự phải lớn hơn {MinValue} và nhỏ hơn {MaxValue}");
            RuleFor(x => x.ClassSize).GreaterThan(0).WithMessage("Sĩ số phải lớn hơn {ComparisonValue}");
            RuleFor(x => x.HomeroomTeacherCode).NotEmpty().WithMessage("Trường này không để trống");
        }
    }
}
