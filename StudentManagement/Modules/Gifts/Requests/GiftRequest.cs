using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Modules.Gifts.Requests
{
    public class GiftRequest
    {
        public string GiftCode { get; set; }
        public byte GiftTypeId { get; set; }
        public string StudentId { get; set; }
        public DateTime AwardDay { get; set; }
        public bool Status { get; set; }
    }
}
