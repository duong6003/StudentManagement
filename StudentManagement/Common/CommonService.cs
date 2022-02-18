using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using StudentManagement.Common;
using StudentManagement.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentManagement
{
    public class CommonService<TSource, TDestination, K>
        where TSource : DomainClass<K>
        where TDestination : class
    {
        private readonly IRepository<TSource, K> _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCache _memoryCache;

        public CommonService(IRepository<TSource, K> repository, IMapper mapper, IUnitOfWork unitOfWork, IMemoryCache cache)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _memoryCache = cache;
        }
        public TSource GetById(K id)
        {
            var entity = _repository.FindById(id);
            return entity;
        }
        public async Task<List<TDestination>> GetAllAsync()
        {
            var listOfEntity = await _repository.FindAll().ProjectTo<TDestination>(_mapper.ConfigurationProvider).ToListAsync();
            return listOfEntity;
        }

        public async Task AddAsync(TDestination entityDto)
        {
            TSource entity = _mapper.Map<TDestination, TSource>(entityDto);
            _repository.Add(entity);
            await SaveAsync();
        }

        public async Task DeleteAsync(K id)
        {
            var entity = _repository.FindById(id);
            _repository.Remove(entity);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(TDestination entityDto)
        {
            TSource entity = _mapper.Map<TDestination, TSource>(entityDto);
            _repository.Update(entity);
            await SaveAsync();
        }

        public virtual bool IsExistId(K id)
        {
            var studentClass = _repository.FindSingle(x => x.Id.Equals(id));
            if (studentClass == null) return false;
            else return true;
        }

        public IEnumerable<TDestination> GetCache(object key)
        {
            bool ok = _memoryCache.TryGetValue(key, out IEnumerable<TDestination> entityCollection);
            if(ok)
            {
                return entityCollection;
            }
            return null;
        }
        public void SetCache(object key, IEnumerable<TDestination> value, MemoryCacheEntryOptions cacheOptions)
        {
            bool ok = _memoryCache.TryGetValue(key, out IEnumerable<TDestination> entityCollection);
            _memoryCache.Set(key, value, cacheOptions);
        }
    }
}