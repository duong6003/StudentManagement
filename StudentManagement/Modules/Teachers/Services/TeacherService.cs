using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using StudentManagement.Common;
using StudentManagement.DataAccess.Interfaces;
using StudentManagement.Models;
using StudentManagement.Modules.Teachers.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Modules.Teachers.Services
{
    public class TeacherService : CommonService<Teacher, TeacherRequest, string>
    {
        private readonly IRepository<Teacher, string> _teacherRepo;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCache _cacheMemory;


        public TeacherService(IRepository<Teacher, string> teacherRepo, IMapper mapper, IUnitOfWork unitOfWork, IMemoryCache cacheMemory) 
            : base(teacherRepo, mapper, unitOfWork, cacheMemory)
        {
            _teacherRepo = teacherRepo;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _cacheMemory = cacheMemory;
        }
        public Teacher FindById(string teacherCode)
        {
            Teacher teacher = _teacherRepo.FindById(teacherCode);
            return teacher;
        }
        public bool IsExistTeacher(string teacherCode)
        {
            var teacher = _teacherRepo.FindSingle(x => x.Id == teacherCode);
            if (teacher == null) return false;
            else return true;
        }
    }
}
