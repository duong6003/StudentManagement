using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using StudentManagement.DataAccess.Interfaces;
using StudentManagement.Models;
using StudentManagement.Modules.Gifts.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Modules.Gifts.Services
{
    public class GiftService : CommonService<Gift, GiftRequest, int>
    {
        private readonly IRepository<Gift, int> giftRepository;
        private readonly IRepository<GiftItem, int> giftItemRepository;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMemoryCache cache;

        public GiftService(IRepository<Gift, int> giftRepository, IMapper mapper, IUnitOfWork unitOfWork, IMemoryCache cache, IRepository<GiftItem, int> giftItemRepository) : base(giftRepository, mapper, unitOfWork, cache)
        {
            this.giftRepository = giftRepository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.cache = cache;
            this.giftItemRepository = giftItemRepository;
        }
        public GetGiftRequest GetGift(string giftCode)
        {
            Gift gift = giftRepository.FindSingle(x => x.GiftCode == giftCode, x=> x.GiftType, x=> x.GiftType.GiftItems);
            return mapper.Map<Gift, GetGiftRequest>(gift);
        }
    }
}
