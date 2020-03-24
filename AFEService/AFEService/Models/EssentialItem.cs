using System;
using System.Collections.Generic;

namespace AFEService.Models
{
    public partial class EssentialItem
    {
        public EssentialItem()
        {
            ItemCategoryFilter = new HashSet<ItemCategoryFilter>();
            ProfileSearchHistory = new HashSet<ProfileSearchHistory>();
        }

        public long EssentialItemId { get; set; }
        public long CategoryId { get; set; }
        public string EssentialItemName { get; set; }
        public int EssentialItemPriority { get; set; }
        public string SearchText { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<ItemCategoryFilter> ItemCategoryFilter { get; set; }
        public virtual ICollection<ProfileSearchHistory> ProfileSearchHistory { get; set; }
    }
}
