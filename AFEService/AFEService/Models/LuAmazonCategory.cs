using System;
using System.Collections.Generic;

namespace AFEService.Models
{
    public partial class LuAmazonCategory
    {
        public LuAmazonCategory()
        {
            ItemCategoryFilter = new HashSet<ItemCategoryFilter>();
        }

        public long AmazonCategoryId { get; set; }
        public long CategoryNodeId { get; set; }
        public string CategoryNodePath { get; set; }
        public string Classification { get; set; }
        public string InventoryTemplateName { get; set; }

        public virtual ICollection<ItemCategoryFilter> ItemCategoryFilter { get; set; }
    }
}
