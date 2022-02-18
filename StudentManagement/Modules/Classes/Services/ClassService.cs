using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Caching.Memory;
using StudentManagement.DataAccess.Interfaces;
using StudentManagement.Models;
using StudentManagement.Modules.Classes.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Modules.Classes.Services
{
    public class ClassService : CommonService<Class, ClassRequest, string>
    {
        private readonly IRepository<Class, string> _classRepo;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCache _cacheMemory;

        public ClassService(IRepository<Class, string> classRepo,
            IMapper mapper, IUnitOfWork unitOfWork, IMemoryCache cacheMemory) 
            : base(classRepo, mapper, unitOfWork, cacheMemory)
        {
            _classRepo = classRepo;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _cacheMemory = cacheMemory;
        }


    }
}
