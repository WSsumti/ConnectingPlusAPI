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
    public class PurchaseController : ControllerBase
    {
        IPurchase _purchase;
        public PurchaseController(IPurchase purchase)
        {
            _purchase = purchase;
        }
        [HttpGet("check/{shopid}/{pos}")]
        public ActionResult<bool> CheckInstore(Guid shopid, int pos)
        {
            return (Ok(_purchase.CheckInStore(shopid, pos)));
        }
        [HttpPost("{shopid}/{pos}/{quantity}")]
        public ActionResult<string> PurchaseItem(Guid shopid, int pos, int quantity)
        {
            _purchase.PurchaseItem(shopid, pos, quantity);
            return Ok();
        }
    }
}
