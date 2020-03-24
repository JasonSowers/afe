using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nager.AmazonProductAdvertising;

namespace AFEService.Utils
{
    public static class APAPIUtils
    {
        public static async Task CallAmazon()
        {
            var authentication = new AmazonAuthentication("{YOUR API KEY}", "{YOUR API SECRET}");
            var client = new AmazonProductAdvertisingClient(authentication, AmazonEndpoint.US, "{YOUR PARTNER TAG}");
            var result = await client.SearchItemsAsync("{SearchQuery}");
        }
    }
}
