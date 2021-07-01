using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServerInfo.Types;

namespace ServerInfo.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CPUInfoController : ControllerBase
    {
        private readonly ILogger<CPUInfoController> _logger;

        public CPUInfoController(ILogger<CPUInfoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<CPUInfo> Get()
        {
            return ResourceManager.GetCPUInfo();
        }
    }
}
