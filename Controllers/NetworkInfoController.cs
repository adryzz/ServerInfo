using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServerInfoAPI.Types;
using System.Net.NetworkInformation;
namespace ServerInfoAPI.Controllers
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
            return ResourceManager.GetNetworkInfo();
        }
    }
}
