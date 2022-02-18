using StudentManagement.Common;
using System;
using System.Collections.Generic;

#nullable disable

namespace StudentManagement.Models
{
    public partial class GiftType: DomainClass<byte>
    {
        public GiftType()
        {
            GiftItems = new HashSet<GiftItem>();
        }

        public string Name { get; set; }

        public virtual ICollection<GiftItem> GiftItems { get; set; }
    }
}
