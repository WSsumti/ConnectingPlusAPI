using ConnectingPlusAPI.Data;
using ConnectingPlusAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectingPlusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PendingsController : ControllerBase
    {
        IProve _prove;
        public PendingsController(IProve prove)
        {
            _prove = prove;
        }
        [HttpPost("pendingrequest")]
        public ActionResult AddToPending(Request request)
        {
            _prove.CreatePending(request);
            return Ok();
        }
        [HttpPost("pendingshoper")]
        public ActionResult AddShoperToPending(Shoper shoper)
        {
            _prove.CreateShopPending(shoper);
            return Ok();
        }
        [HttpGet("getlist")]
        public ActionResult<List<Request>> GetAllPending()
        {
            return Ok(_prove.GetAllRequest());
        }
    }
}
