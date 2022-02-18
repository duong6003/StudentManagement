using AutoMapper;
using AutoMapper.QueryableExtensions;
using StudentManagement.Models;
using StudentManagement.Modules.GiftItems.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Modules.Gifts.Requests
{
    public class GetGiftRequest
    {
        public string GiftTypeName { get; set; }
        public DateTime AwardDay { get; set; }
        public bool Status { get; set; }
        public ICollection<GetGiftItemRequest> GiftItemRequests { get; set; }
    }
}
