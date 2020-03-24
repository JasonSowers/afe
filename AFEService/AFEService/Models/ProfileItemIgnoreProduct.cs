using System;
using System.Collections.Generic;

namespace AFEService.Models
{
    public partial class ProfileItemIgnoreProduct
    {
        public long ProfileItemIgnoreProductId { get; set; }
        public long? ProfileItemId { get; set; }
        public string AmazonProductId { get; set; }

        public virtual ProfileItem ProfileItem { get; set; }
    }
}
