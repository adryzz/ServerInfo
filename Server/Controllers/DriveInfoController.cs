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
    public class DriveInfoController : ControllerBase
    {
        private readonly ILogger<DriveInfoController> _logger;

        public DriveInfoController(ILogger<DriveInfoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Drive> Get()
        {
            return DriveHelper.GetDrives();
        }
    }
}
