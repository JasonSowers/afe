using System;
using System.Collections.Generic;

namespace AFEService.Models
{
    public partial class Profile
    {
        public Profile()
        {
            ProfileItem = new HashSet<ProfileItem>();
            ProfileSearchHistory = new HashSet<ProfileSearchHistory>();
        }

        public long ProfileId { get; set; }
        public string ProfileGuid { get; set; }
        public string EmailAddress { get; set; }

        public virtual ICollection<ProfileItem> ProfileItem { get; set; }
        public virtual ICollection<ProfileSearchHistory> ProfileSearchHistory { get; set; }
    }
}
