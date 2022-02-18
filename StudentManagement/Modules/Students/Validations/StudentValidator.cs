using FluentValidation;
using StudentManagement.Extentions;
using StudentManagement.Modules.Students.Requests;
using StudentManagement.Modules.Students.Services.Implements;

namespace StudentManagement.Modules.Students.Validations
{
    public class StudentValidator : AbstractValidator<StudentRequest>
    {
        private readonly StudentService _studentService;
        public StudentValidator(StudentService studentService)
        {
            _studentService = studentService;
            RuleFor(x => x.StudentId)
                .NotEmpty().WithMessage("Trường này không được để trống")
                .MaximumLength(10).WithMessage("Mã lớp không quá mười kí tự")
                .Matches("[a-z0-9]").WithMessage("Không chứa kí tự đặc biệt")
                .Must((student, id , context) => _studentService.IsExistId(id)).WithMessage("Mã không tồn tại"); ;

            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Trường này không được để trống")
                .Length(1, 7).WithMessage("Tên dưới không dưới {MinLength} kí tự, ít hơn {MaxLength} kí tự")
                .Matches(@"^[a-zA-ZÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼỀỀỂẾưăạảấầẩẫậắằẳẵặẹẻẽềềểếỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễệỉịọỏốồổỗộớờởỡợụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹ\s\W|_]+$").WithMessage("Tên không được chứa chữ số")
                .IsCapitalizeFirstLetter();
            RuleFor(x => x.Address).Length(0, 128).WithMessage("Địa chỉ dưới {MaxLength} kí tự");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Trường này phải là Email");
            //Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
        }
    }
}