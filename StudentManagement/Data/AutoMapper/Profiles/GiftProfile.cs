using AutoMapper;
using StudentManagement.Models;
using StudentManagement.Modules.GiftItems.Requests;
using StudentManagement.Modules.Gifts.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Data.AutoMapper.Profiles
{
    public class GiftProfile : Profile
    {
        public GiftProfile()
        {
            CreateMap<Gift, GetGiftRequest>()
                .ForMember(dest => dest.GiftTypeName, opt => opt.MapFrom(src => src.GiftType.Name))
                .ForMember(dest => dest.GiftItemRequests, opt => opt.MapFrom(src => src.GiftType.GiftItems));
            CreateMap<GiftItem, GetGiftItemRequest>();
            CreateMap<GetGiftItemRequest, GetGiftRequest>(MemberList.None);
        }
    }
}
