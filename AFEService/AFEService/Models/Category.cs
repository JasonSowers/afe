using System;
using System.Collections.Generic;

namespace AFEService.Models
{
    public partial class Category
    {
        public Category()
        {
            EssentialItem = new HashSet<EssentialItem>();
        }

        public long CategoryId { get; set; }
        public int TemplateId { get; set; }
        public string CategoryName { get; set; }

        public virtual Template Template { get; set; }
        public virtual ICollection<EssentialItem> EssentialItem { get; set; }
    }
}
