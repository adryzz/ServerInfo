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
    public class MemoryInfoController : ControllerBase
    {
        private readonly ILogger<MemoryInfoController> _logger;

        public MemoryInfoController(ILogger<MemoryInfoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public MemoryInfo Get()
        {
            return ResourceManager.GetMemoryInfo();
        }
    }
}
