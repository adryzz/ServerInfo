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
    public class DiskInfoController : ControllerBase
    {
        private readonly ILogger<DiskInfoController> _logger;

        public DiskInfoController(ILogger<DiskInfoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Disk> Get()
        {
            return ResourceManager.GetDisks();
        }
    }
}
