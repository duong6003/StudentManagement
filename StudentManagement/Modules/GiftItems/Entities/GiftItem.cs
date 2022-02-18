using StudentManagement.Common;
using System;
using System.Collections.Generic;

#nullable disable

namespace StudentManagement.Models
{
    public partial class GiftItem : DomainClass<int>
    {
        public string ItemName { get; set; }
        public byte GiftTypeId { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }

        public virtual GiftType GiftType { get; set; }
    }
}
