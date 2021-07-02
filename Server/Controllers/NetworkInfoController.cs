using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServerInfo.Types;
using ServerInfo.API.ResourceHelpers;

namespace ServerInfo.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class NetworkInfoController : ControllerBase
    {
        private readonly ILogger<NetworkInfoController> _logger;

        public NetworkInfoController(ILogger<NetworkInfoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<AdvancedNetworkInterface> Get()
        {
            return NetworkHelper.GetNetworkInfo();
        }
    }
}
