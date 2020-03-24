using System;
using System.Collections.Generic;

namespace AFEService.Models
{
    public partial class Template
    {
        public Template()
        {
            Category = new HashSet<Category>();
        }

        public int TemplateId { get; set; }
        public string TemplateName { get; set; }
        public bool IsSystemDefault { get; set; }

        public virtual ICollection<Category> Category { get; set; }
    }
}
