using System;
using System.Collections.Generic;

namespace AFEService.Models
{
    public partial class ItemCategoryFilter
    {
        public long ItemCategoryFilterId { get; set; }
        public long EssentialItemId { get; set; }
        public long AmazonCategoryId { get; set; }

        public virtual LuAmazonCategory AmazonCategory { get; set; }
        public virtual EssentialItem EssentialItem { get; set; }
    }
}
