using System;
using System.Collections.Generic;

namespace AFEService.Models
{
    public partial class ProfileSearchHistory
    {
        public ProfileSearchHistory()
        {
            ProfileNotification = new HashSet<ProfileNotification>();
            SearchHistoryFilterState = new HashSet<SearchHistoryFilterState>();
        }

        public long ProfileSearchHistoryId { get; set; }
        public long ProfileId { get; set; }
        public DateTime SearchDateTimeUtc { get; set; }
        public long? EssentialItemId { get; set; }
        public string CategoryScopeFilterOverrided { get; set; }
        public string SearchText { get; set; }

        public virtual EssentialItem EssentialItem { get; set; }
        public virtual Profile Profile { get; set; }
        public virtual ICollection<ProfileNotification> ProfileNotification { get; set; }
        public virtual ICollection<SearchHistoryFilterState> SearchHistoryFilterState { get; set; }
    }
}
