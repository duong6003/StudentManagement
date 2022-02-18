using StudentManagement.Common;
using System;
using System.Collections.Generic;

#nullable disable

namespace StudentManagement.Models
{
    public partial class Gift: DomainClass<int>
    {
        public string GiftCode { get; set; }
        public byte GiftTypeId { get; set; }
        public DateTime AwardDay { get; set; }
        public bool Status { get; set; }

        public virtual GiftType GiftType { get; set; }
    }
}
