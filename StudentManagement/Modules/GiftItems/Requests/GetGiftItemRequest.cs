using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Modules.GiftItems.Requests
{
    public class GetGiftItemRequest
    {
        public string ItemName { get; set; }
        public string Unit { get; set; }
    }
}
