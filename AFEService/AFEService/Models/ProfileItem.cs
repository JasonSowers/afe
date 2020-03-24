using System;
using System.Collections.Generic;

namespace AFEService.Models
{
    public partial class ProfileItem
    {
        public ProfileItem()
        {
            ProfileItemIgnoreProduct = new HashSet<ProfileItemIgnoreProduct>();
        }

        public long ProfileItemId { get; set; }
        public long ProfileId { get; set; }
        public long EssentialItemId { get; set; }
        public DateTime? DtNeededBy { get; set; }
        public int? PriorityOverride { get; set; }
        public string SearchTextOverride { get; set; }

        public virtual Profile Profile { get; set; }
        public virtual ICollection<ProfileItemIgnoreProduct> ProfileItemIgnoreProduct { get; set; }
    }
}
