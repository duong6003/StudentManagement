using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using StudentManagement.Common;
using StudentManagement.Constants;
using StudentManagement.Modules.ExamResults.Requests;
using StudentManagement.Modules.Students.Requests;
using StudentManagement.Modules.Students.Services.Implements;
using StudentManagement.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentManagement.Modules.Students.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class StudentController : ControllerBase
    {
        private readonly StudentService _studentService;

        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("get-student-info")]
        public async Task<IActionResult> GetStudentAsync()
        {
            var cacheModel = _studentService.GetCache(CacheKey.StudentCache.STUDENT_COLLECTION);
            if (cacheModel is null)
            {
                var model = await _studentService.GetAllAsync();
                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(2))
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(5));

                _studentService.SetCache(CacheKey.StudentCache.STUDENT_COLLECTION, model, cacheOptions);
                return Ok(new GenericResponse(model, ResponseConstant.SUCCESS_RESPONSE));
            }
            return Ok(new GenericResponse(cacheModel, ResponseConstant.SUCCESS_RESPONSE));
        }

        [HttpPost("add-student")]
        public async Task<IActionResult> AddAsync(StudentRequest studentRequest)
        {
            await _studentService.AddAsync(studentRequest);
            return Ok(new GenericResponse(null ,ResponseConstant.SUCCESS_RESPONSE));
        }
        [HttpGet("get-mark")]
        public async Task<IActionResult> GetExamResult(string studentCode)
        {
            if (_studentService.IsExistId(studentCode) is false)
                return BadRequest(new GenericResponse(null, ResponseConstant.NOT_FOUND));

            List<GetExamResultRequet> studentMark = await _studentService.GetMarkResult(studentCode);
            return Ok(new GenericResponse(studentMark, ResponseConstant.SUCCESS_RESPONSE));
        }
        [HttpPost("upload-file")]
        public async Task<IActionResult> UploadProfile([FromQuery]UpdateStudentRequest updateStudent)
        { 
            string path = await _studentService.UploadFileAsync(updateStudent);

            //update student
            var student = _studentService.GetById(updateStudent.StudentId);
            student.CurriculumVitae = path;
            await _studentService.UpdateAsync(student);

            return Ok(new GenericResponse(path, ResponseConstant.SUCCESS_RESPONSE));
        }
    }
}