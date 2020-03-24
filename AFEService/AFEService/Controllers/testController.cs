using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AFEService.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AFEService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        // GET: api/test
        [HttpGet]
        public async Task<IEnumerable<string>>Get()
        {
            await APAPIUtils.CallAmazon();
            return new string[] { "value1", "value2" };
        }

    }
}
