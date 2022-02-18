using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using StudentManagement.DataAccess.Interfaces;
using StudentManagement.Models;
using StudentManagement.Modules.ExamResults.Requests;
using StudentManagement.Modules.Students.Requests;
using StudentManagement.Modules.Students.Validations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Modules.Students.Services.Implements
{
    public class StudentService : CommonService<Student, StudentRequest, string>
    {
        private readonly IRepository<Student, string> _studentRepo;
        private readonly IRepository<ExamResult, int> _examRepo;
        private readonly IWebHostEnvironment _webHost;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cacheMemory;

        public StudentService(IRepository<Student, string> studentRepo,
            IMapper mapper, IUnitOfWork unitOfWork, IMemoryCache cacheMemory, IRepository<ExamResult, int> examRepo, IWebHostEnvironment webHost)
            : base(studentRepo, mapper, unitOfWork, cacheMemory)
        {
            _studentRepo = studentRepo;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _cacheMemory = cacheMemory;
            _examRepo = examRepo;
            _webHost = webHost;
        }
        public async Task<List<GetExamResultRequet>> GetMarkResult(string studentCode)
        {
            Student student = _studentRepo.FindById(studentCode);
            List<GetExamResultRequet> studentExamResult = await _examRepo.FindAll(x => x.StudentId == studentCode).ProjectTo<GetExamResultRequet>(_mapper.ConfigurationProvider).ToListAsync();
            return studentExamResult;
        }
        public async Task<string> UploadFileAsync(UpdateStudentRequest updateStudent)
        {
            string fileUpload = $@"\CurriculumVitae\Students\{DateTime.Now.ToString("yyyyMMdd")}";
            string folder = _webHost.WebRootPath + fileUpload;
            if (Directory.Exists(folder) is false)
            {
                Directory.CreateDirectory(folder);
            }
            //handle file name
            var fileName = updateStudent.CurriculumVitae.FileName;
            string filePath = Path.Combine(folder,fileName);

            //Copy file to folder root
            using FileStream fs = File.Create(filePath);
            await updateStudent.CurriculumVitae.CopyToAsync(fs);
            await fs.FlushAsync();

            return filePath;
        }
        public bool IsValidFile(IFormFile file)
        {
            bool ok = file.ContentType.Contains("application/pdf") ? true : false;
            return ok;
        }
        public async Task UpdateAsync(Student student)
        {
            _studentRepo.Update(student);
            await SaveAsync();
        }
    }
}
