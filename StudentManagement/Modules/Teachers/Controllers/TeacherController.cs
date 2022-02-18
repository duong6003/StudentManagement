using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Constants;
using StudentManagement.Modules.Teachers.Requests;
using StudentManagement.Modules.Teachers.Services;
using StudentManagement.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Modules.Teachers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly TeacherService _teacherService;

        public TeacherController(TeacherService teacherService)
        {
            _teacherService = teacherService;
        }
        [HttpGet("get-all-teacher")]
        public async Task<IActionResult> GetAll()
        {
            var model = await _teacherService.GetAllAsync();
            return Ok(new GenericResponse(model, ResponseConstant.SUCCESS_RESPONSE));
        }
        [HttpPost("add-teacher")]
        public async Task<IActionResult> Add(TeacherRequest teacherReq)
        {
            await _teacherService.AddAsync(teacherReq);
            return Ok(new GenericResponse(teacherReq, ResponseConstant.SUCCESS_RESPONSE));
        }
        [HttpPut("update-teacher")]
        public async Task<IActionResult> Update(TeacherRequest teacherReq)
        {
            if (_teacherService.IsExistTeacher(teacherReq.TeacherCode))
            {
                await _teacherService.UpdateAsync(teacherReq);
                return Ok(new GenericResponse(teacherReq, ResponseConstant.SUCCESS_RESPONSE));
            }
            else return BadRequest(new GenericResponse(teacherReq, ResponseConstant.NOT_FOUND));
        }
    }
}
