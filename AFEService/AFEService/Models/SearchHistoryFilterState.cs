using System;
using System.Collections.Generic;

namespace AFEService.Models
{
    public partial class SearchHistoryFilterState
    {
        public long SearchHistoryFilterStateId { get; set; }
        public long? ProfileSearchHistoryId { get; set; }
        public int SearchFilterId { get; set; }
        public bool FilterState { get; set; }

        public virtual ProfileSearchHistory ProfileSearchHistory { get; set; }
        public virtual LuSearchFilter SearchFilter { get; set; }
    }
}
