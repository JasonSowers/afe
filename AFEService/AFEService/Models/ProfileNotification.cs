using System;
using System.Collections.Generic;

namespace AFEService.Models
{
    public partial class ProfileNotification
    {
        public long ProfileNotificationId { get; set; }
        public long ProfileSearchHistoryId { get; set; }
        public string NotificationName { get; set; }
        public DateTime DtLastSearch { get; set; }
        public bool DtSearchResultsFound { get; set; }
        public DateTime DtNotificationSent { get; set; }
        public bool DisableNotification { get; set; }

        public virtual ProfileSearchHistory ProfileSearchHistory { get; set; }
    }
}
