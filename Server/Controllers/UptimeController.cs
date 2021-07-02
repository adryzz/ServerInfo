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
    public class UptimeInfoController : ControllerBase
    {
        private readonly ILogger<UptimeInfoController> _logger;

        public UptimeInfoController(ILogger<UptimeInfoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public UptimeInfo Get()
        {
            return UptimeHelper.GetUptimeInfo();
        }
    }
}
