using FluentValidation;
using StudentManagement.Common;
using StudentManagement.DataAccess.Interfaces;
using StudentManagement.Extentions;
using StudentManagement.Models;
using StudentManagement.Modules.Teachers.Requests;
using StudentManagement.Modules.Teachers.Services;

namespace StudentManagement.Modules.Teachers.Validations
{
    public class TeacherRequestValidator : AbstractValidator<TeacherRequest>
    {
        private readonly TeacherService _teacherService;
        public TeacherRequestValidator(TeacherService teacherService)
        {
            _teacherService = teacherService;
            RuleFor(x => x.Coefficient).GreaterThanOrEqualTo(1).WithMessage("Hệ số lương phải lớn hơn hoắc bằng {ComparisonValue}");
            RuleFor(x => x.TeacherCode)
                .NotEmpty().WithMessage("{PropertyName} không được để trống")
                .Length(3, 20).WithMessage("Số kí tự phải lớn hơn {MinValue} và nhỏ hơn {MaxValue}");
            RuleFor(x => x.FullName)
               .NotEmpty().WithMessage("Trường này không được để trống")
               .Length(5, 100).WithMessage("Tên dưới không dưới {MinLength} kí tự, ít hơn {MaxLength} kí tự")
               .Matches(@"^[a-zA-ZÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼỀỀỂẾưăạảấầẩẫậắằẳẵặẹẻẽềềểếỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễệỉịọỏốồổỗộớờởỡợụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹ\s\W|_]+$").WithMessage("Tên không được chứa chữ số")
               .IsCapitalizeFirstLetter();
            RuleFor(x => x.Salary).NotEqual(0).WithMessage("Lương không được bằng {ComparisonValue}");
            RuleFor(x => x.Id)
                .Must((entity, id) => 
                {
                    bool exists = _teacherService.IsExistId(id);
                    return exists;
                }
                ).WithMessage("Id không khớp");
        }
    }
}