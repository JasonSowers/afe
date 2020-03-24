using System;
using System.Collections.Generic;

namespace AFEService.Models
{
    public partial class LuSearchFilter
    {
        public LuSearchFilter()
        {
            SearchHistoryFilterState = new HashSet<SearchHistoryFilterState>();
        }

        public int SearchFilterId { get; set; }
        public string SearchFilter { get; set; }
        public bool DefaultOn { get; set; }

        public virtual ICollection<SearchHistoryFilterState> SearchHistoryFilterState { get; set; }
    }
}
