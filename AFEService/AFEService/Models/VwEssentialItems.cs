using System;
using System.Collections.Generic;

namespace AFEService.Models
{
    public partial class VwEssentialItems
    {
        public string TemplateName { get; set; }
        public string CategoryName { get; set; }
        public string EssentialItemName { get; set; }
        public int? EssentialItemPriority { get; set; }
        public string AmazonCategories { get; set; }
        public string SearchText { get; set; }
        public long? EssentialItemId { get; set; }
        public long CategoryId { get; set; }
        public int TemplateId { get; set; }
    }
}
